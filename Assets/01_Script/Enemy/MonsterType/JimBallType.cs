using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JimBallType : BulletTrans
{
    int HP;

    public override void Reset()
    {
        HP = 30;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            HP--;
        }
        if(HP == 0)
        {
            PoolManager.Instance.Push(this);
        }
    }
}
