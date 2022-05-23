using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TurletType : BulletTrans
{
    Animator Ani;
    Sequence seq;
    float X;
    float Y;

    bool isTrigger;
    public override void Reset()
    {
        X = GameObject.Find("Player/Hit").GetComponent<Transform>().transform.position.x;
        Y = 5.5f;
        transform.position = new Vector3(X, Y, 0);
        StartCoroutine(Fire());
        isTrigger = false;
    }

    void Start()
    {
        X = GameObject.Find("Player/Hit").GetComponent<Transform>().transform.position.x;
        Y = 5.5f;
        Ani = gameObject.GetComponent<Animator>();
        isTrigger = false;
    }

    IEnumerator Fire()
    {
        seq = DOTween.Sequence()
        .Append(transform.DOMove(new Vector3(X, Y, 0), 1).SetEase(Ease.Linear))
        .Append(transform.DOMove(new Vector3(X, 5.1f, 0), 1).SetEase(Ease.Linear));
        yield return new WaitForSeconds(2f);

        Ani.SetTrigger("Shot");

        seq = DOTween.Sequence().Append(transform.DOMove(new Vector3(X, Y, 0), 1).SetEase(Ease.Linear));
        yield return new WaitForSeconds(1f);
        PoolManager.Instance.Push(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && isTrigger == true)
        {
            Debug.Log("플레이어 맞음");
        }


    }
}
