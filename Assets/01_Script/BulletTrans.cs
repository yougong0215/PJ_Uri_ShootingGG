using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class BulletTrans : MonoBehaviour
{
    // 1 : 30
    protected Vector3 dir;
    float currentTIme;
    public abstract void Reset();
    [SerializeField]
    protected float HP;

    public void Awake()
    {
        currentTIme = 0;
        dir = Vector3.down;
    }
    public void SetHp(int value)
    {
        HP = value;
    }
    public void Update()
    {
        if (transform.parent.GetComponent<Stage1Patton>() == false)
        {
            transform.position += 3 * dir * Time.deltaTime;
        }

    }

    public void LateUpdate()
    {

        if (Mathf.Abs(transform.position.y) >= 10f)
        {
            currentTIme += Time.deltaTime;
            if (currentTIme >= 2)
            {
                PoolManager.Instance.Push(this);
            }
        }
        else
        {
            currentTIme = 0;
        }
    }
    public void SetDir(Vector3 value)
    {
        dir += value;
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            HP -= collision.GetComponent<PlayerBullet>().GetDamage();
            PoolManager.Instance.Push(collision.GetComponent<BulletTrans>());
        }
        if (HP <= 0)
        {
            PoolManager.Instance.Push(this);
        }
        if(collision.gameObject.CompareTag("PlayerHit"))
        {
        }
    }
    public void GetDamage(float value)
    {
        HP -= value;
        Debug.Log($"{gameObject}, {HP}");
        if (HP <= 0) PoolManager.Instance.Push(this);
    }
}
