using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TurletType : BulletTrans
{
    Animator Ani;
    BoxCollider2D box;
    SpriteRenderer spi;
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
        spi = gameObject.GetComponent<SpriteRenderer>();
        box = gameObject.GetComponent<BoxCollider2D>();
        isTrigger = false;
        box.size = new Vector2(0.2f, 0.2f);
        box.offset = new Vector2(0.0f, 0.05f);
    }
    private void Update()
    {
        if (spi.sprite.name == "Sprite-0001_0")
        {
            box.size = new Vector2(0.2f, 0.2f);
            box.offset = new Vector2(0.0f, 0.05f);
        }
        else if (spi.sprite.name == "Sprite-0001_3")
        {
            box.size = new Vector2(0.2f, 1.2f);
            box.offset = new Vector2(0.0f, 0.6f);
        }
        else if (spi.sprite.name == "Sprite-0001_4")
        {
            box.size = new Vector2(0.2f, 2f);
            box.offset = new Vector2(0.0f, 1f);
        }
        else if (spi.sprite.name == "Sprite-0001_5")
        {
            box.size = new Vector2(0.2f, 2.7f);
            box.offset = new Vector2(0.0f, 1.2f);
        }
    }

    IEnumerator Fire()
    {
        seq = DOTween.Sequence()
        .Append(transform.DOMove(new Vector3(X, Y, 0), 1).SetEase(Ease.Linear))
        .Append(transform.DOMove(new Vector3(X, 5.1f, 0), 1).SetEase(Ease.Linear));
        yield return new WaitForSeconds(2f);

        Ani.SetTrigger("Shot");
                isTrigger = true;
        seq = DOTween.Sequence().Append(transform.DOMove(new Vector3(X, Y, 0), 1).SetEase(Ease.Linear));
        yield return new WaitForSeconds(1f);

        yield return new WaitForSeconds(0.2f);
        box.size = new Vector2(0.2f, 0.2f);
        box.offset = new Vector2(0.0f, 0.05f);
        PoolManager.Instance.Push(this);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"istrigger : {isTrigger} | {collision.gameObject.CompareTag("PlayerHit")} 플레이어 맞ㄱ잇냐");
        if(collision.gameObject.CompareTag("PlayerHit") && isTrigger == true)
        {
            //Debug.Log("조건 충족함");
            GameManager.Instance.SetDamaged(true);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
}
