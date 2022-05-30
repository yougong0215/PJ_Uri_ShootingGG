using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class BulletTrans : MonoBehaviour
{
    Vector3 dir;
    public abstract void Reset();
    protected float HP;

    public void Awake()
    {
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
        if (Mathf.Abs(transform.position.y) >= 10f)
        {
            PoolManager.Instance.Push(this);
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
}
