using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class BulletTrans : MonoBehaviour
{
    public abstract void Reset();
    protected float HP;

    public void SetHp(int value)
    {
        HP = value;
    }
    public void Update()
    {
        if (transform.parent.GetComponent<Stage1Patton>() == false)
        {
            transform.position += 3 * Vector3.down * Time.deltaTime;
        }
        if (Mathf.Abs(transform.position.y) >= 7f)
        {
            PoolManager.Instance.Push(this);
        }

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
