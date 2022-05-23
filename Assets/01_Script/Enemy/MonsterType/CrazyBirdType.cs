using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyBirdType : BulletTrans
{
    // �� BulletBullet�� �����
    BlueBullet BB;
    const string Type1 = "CrazyBirdType1";
    const string Type2 = "CrazyBirdType2";


    bool isType;
    // 0�� 1�� ��� ����
    [SerializeField]
    int HP;
    int i;
    public override void Reset()
    {
        
        i = 0;
        HP = 120;
    }





    private void OnEnable()
    {
        StartCoroutine(CRType());
    }
    public void Type()
    {
        if (gameObject.name == Type1) // 3���� ����
        {
            StartCoroutine(CRType1());
        }
        else if (gameObject.name == Type2) // �÷��̾� ���� ���
        {
            StartCoroutine(CRType2());
        }
        StartCoroutine(CRType());
    }


    IEnumerator CRType1()
    {
        for (i = 0; i < 3; i++)
        {
            BB = PoolManager.Instance.Pop("BlueBullet") as BlueBullet;
            BB.SetDir(i, 4, 0, gameObject);
            BB.transform.position = transform.position;
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator CRType2()
    {
        for (i = 0; i < 3; i++)
        {
            BB = PoolManager.Instance.Pop("BlueBullet") as BlueBullet;
            BB.SetDir(i, 6, 1, gameObject);
            BB.transform.position = transform.position;
            yield return new WaitForEndOfFrame();
        }
    }


    IEnumerator CRType()
    {
        yield return new WaitForSeconds(2f);
        Type();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            HP--;
        }
        if (HP <= 0)
        {
            PoolManager.Instance.Push(this);
        }
    }
}
