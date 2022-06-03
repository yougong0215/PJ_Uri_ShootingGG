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
    const string Type1 = "TurletType1";
    const string Type2 = "TurletType2";
    const string Type3 = "TurletType3";
    bool isTrigger;
    public override void Reset()
    {
        X = 10;
        Y = 10;
        StartCoroutine(Fire());
        isTrigger = false;
    }

    void Start()
    {
        X = 10;
        Y = 10;
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

        if (gameObject.name == Type1)
        {   X = GameObject.Find("Player/Hit").GetComponent<Transform>().transform.position.x;
            Y = 5.5f;
            transform.position = new Vector3(X, Y, 0);
            seq = DOTween.Sequence()
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
        else if (gameObject.name == Type2)
        {
            X = -7f;
            Y = GameObject.Find("Player/Hit").GetComponent<Transform>().transform.position.y;
            transform.position = new Vector3(X, Y, 0);
            seq = DOTween.Sequence()
            .Append(transform.DOMove(new Vector3(-7f, Y, 0), 1).SetEase(Ease.Linear));
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
        else if (gameObject.name == Type2)
        {
            X = 0.6f;
            Y = GameObject.Find("Player/Hit").GetComponent<Transform>().transform.position.y;
            transform.position = new Vector3(X, Y, 0);
            seq = DOTween.Sequence()
            .Append(transform.DOMove(new Vector3(0.3f, Y, 0), 1).SetEase(Ease.Linear));
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
    }

}
