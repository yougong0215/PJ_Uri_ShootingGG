using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PowerItem : BulletTrans
{
    Sequence MoveUp;
    PlayerHP GetHPRegister;

    public override void Reset()
    {
        HP = 10000;
    }
    

    public void SetPos(Vector3 vec)
    {
        HP = 10000;
        transform.position = vec;
    }

    void Start()
    {
        MoveUp = DOTween.Sequence().SetAutoKill(false).Append(transform.DOMoveY(transform.position.y + 2, 1));
        // DomoveY������? �ٵ� �̹� DOMove�� ���ɿ�
    }

    private void OnEnable()
    {
        MoveUp.Restart();

    }

    public void Pl()
    {
        StopAllCoroutines();
        DOTween.Sequence().SetAutoKill(false).Append(transform.DOMove(new Vector3(Random.Range(-4.9f, 0.9f), Random.Range(2.9f, 4f), 3), 0.3f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += 3 * Vector3.down * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            PoolManager.Instance.Push(this);
        }
    }
}
