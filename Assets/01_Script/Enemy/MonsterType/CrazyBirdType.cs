using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CrazyBirdType : BulletTrans
{
    // �� BulletBullet�� �����

    BlueBullet BB;
    const string Type1 = "CrazyBirdType1";
    const string Type2 = "CrazyBirdType2";

    const string Patten1 = "StagePattern1";
    const string Patten2 = "StagePattern2";
    const string Patten3 = "StagePattern3";
    const string Patten4 = "StagePattern4";
    Vector3 dir;
    string nameing;
    bool isType;
    float currentTIme;
    // 0�� 1�� ��� ����

    AudioSource _audio;
    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }
    int i;
    public override void Reset()
    {
        
        i = 0;
    }
    public Vector3 ParentRotate
    {
        get;

        set;
    }




    private void OnEnable()
    {
        currentTIme = 0;
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

    public void LateUpdate()
    {
        currentTIme += Time.deltaTime;
        if (transform.parent == null)
        {
            if (currentTIme >= 4f)
            {
                PoolManager.Instance.Push(this);
            }

            if (Mathf.Abs(transform.position.y) >= 15f)
            {
                PoolManager.Instance.Push(this);
            }
        }
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
                BB.SetDir(i,4, 1, gameObject);
                BB.transform.position = transform.position;
            yield return new WaitForSeconds(0.1f);
            
        }
    }


    IEnumerator CRType()
    {
        yield return new WaitForSeconds(2f);
        Type();
    }
}
