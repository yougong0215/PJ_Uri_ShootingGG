using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WillType : EnemyHPMaster
{
    Sequence seq;

    private void OnEnable()
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
         .Append(transform.DOMove(new Vector3(-5f, 1.5f, 0), 1).SetEase(Ease.Linear));

    }

    void Update()
    {
        
    }
}
