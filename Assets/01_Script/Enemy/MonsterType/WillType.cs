using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WillType : BulletTrans
{
    Sequence seq;
    int HP;
    public override void Reset()
    {
        HP = 30;
        MoveType();
    }

    void MoveType()
    {
        transform.position = new Vector2(3.5f, 3.5f);
        seq = DOTween.Sequence()
         .Append(transform.DOMove(new Vector3(-5f, 3.5f, 0), 1).SetEase(Ease.Linear))
         .Append(transform.DOMove(new Vector3(-6f, 2f, 0), 1).SetEase(Ease.Linear))
         .Append(transform.DOMove(new Vector3(-5f, 0.5f, 0), 1).SetEase(Ease.Linear));

    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            HP--;


        }
        if (HP == 0)
        {
            PoolManager.Instance.Pop("BuleBullet");
        }
    }
}
