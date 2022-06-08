using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class BulletTrans : MonoBehaviour
{
    // 1 : 30
    protected Vector3 dir;
    float currentTIme;
    int ItemRandom;
    public abstract void Reset();
    protected float HP;

    public void Awake()
    {
        currentTIme = 0;
        dir = Vector3.down;
    }
    public void SetHp(float value)
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
            CreateItem();
        }
        if(collision.gameObject.CompareTag("PlayerHit"))
        {
        }
    }
    public void GetDamage(float value)
    {
        HP -= value;
        //Debug.Log($"{gameObject}, {HP}");
        if (HP <= 0) PoolManager.Instance.Push(this);
    }
    public void CreateItem()
    {
        ItemRandom = UnityEngine.Random.Range(0, 101);
        if (ItemRandom >= 20 && ItemRandom < 70)
        {

        }
        else if (ItemRandom > 1 && ItemRandom < 20)
        {

        }
        else if(ItemRandom <= 1)
        {

        }
        PoolManager.Instance.Pop("Power_Item");
    }
}
