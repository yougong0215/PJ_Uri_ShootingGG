using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletTrans : MonoBehaviour
{
    public abstract void Reset();
    protected float HP;
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
            GameManager.Instance.SetDamaged(true);
        }
    }
}
