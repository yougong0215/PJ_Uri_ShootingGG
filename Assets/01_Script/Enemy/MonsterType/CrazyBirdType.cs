using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyBirdType : EnemyHPMaster
{
    // 옌 BulletBullet만 사용함
    // 0번 1번 사용 가능

    enum ShootType
    {
        TripleShoot = 0,
        ZoomShoot = 1
    }
    int i;

    const string Type1 = "CrazyBirdType1";
    const string Type2 = "CrazyBirdType2";

    BlueBullet Script;
    BulletManager Manager;

    bool isType;
    private void Start()
    {
        Manager = GetComponent<BulletManager>();
        i = 0;
        HP = 30;
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
    public void Type(GameObject obj)
    {
        Script = obj.GetComponent<BlueBullet>();
        if (gameObject.name == Type1) // 3방향 난사
        {
            for (i = 0; i < 3; i++)
                Script.SetDir(i, 4, 0, gameObject);
        }
        else if (gameObject.name == Type2) // 플레이어 방향 쏘기
        {
            for (i = 0; i < 3; i++)
                Script.SetDir(i, 8, 1, gameObject);
        }
        isType = false;
    }

    IEnumerator CRType()
    {
        yield return new WaitForSeconds(2f);
        isType = true;
    }
}
