using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PowerItem : BulletTrans
{
    Sequence MoveUp;
    public override void Reset()
    {
    }
    

    public void SetPos(Vector3 vec)
    {
        transform.position = vec;
    }

    void Start()
    {
        MoveUp = DOTween.Sequence().SetAutoKill(false).Append(transform.DOMoveY(transform.position.y + 3, 1));
        // DomoveY쓰라고요? 근데 이미 DOMove를 쓴걸요
    }

    private void OnEnable()
    {
        MoveUp.Restart();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = 4 * Vector3.down * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            PoolManager.Instance.Push(this);
        }
    }
}
