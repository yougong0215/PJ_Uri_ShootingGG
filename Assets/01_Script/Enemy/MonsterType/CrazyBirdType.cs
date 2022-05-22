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

    int HP;
    int i;
    public override void Reset()
    {
        
        i = 0;
        HP = 30;
    }

    private void Update()
    {
        if (HP <= 0)
        {
            gameObject.SetActive(false);
        }
    }



    private void LateUpdate()
    {
        if (isType == false)
        {
        }
    }
    private void OnEnable()
    {
        StartCoroutine(CRType());
    }
    public void Type()
    {
        if (gameObject.name == Type1) // 3���� ����
        {
            for (i = 0; i < 3; i++)
            {
                BB = PoolManager.Instance.Pop("BlueBullet") as BlueBullet;
                BB.SetDir(i, 4, 0, gameObject);
                BB.transform.position = transform.position;
            }
        }
        else if (gameObject.name == Type2) // �÷��̾� ���� ���
        {
            for (i = 0; i < 3; i++)
            {
                BB = PoolManager.Instance.Pop("BlueBullet") as BlueBullet;
                BB.SetDir(i, 8, 1, gameObject);
                BB.transform.position = transform.position;
            }
        }
        StartCoroutine(CRType());
    }

    IEnumerator CRType()
    {
        yield return new WaitForSeconds(2f);
        Type();
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
