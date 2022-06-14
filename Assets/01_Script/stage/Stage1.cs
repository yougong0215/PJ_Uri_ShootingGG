using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stage1 : MonoBehaviour
{
    const string CBType1 = "CrazyBirdType1";
    const string CBType2 = "CrazyBirdType2";
    const string JBType = "Jimball";
    const string TuretType1 = "TurletType1";
    const string TuretType2 = "TurletType2";
    const string TuretType3 = "TurletType3";
    const string Patten1 = "StagePattern1";
    const string Patten2 = "StagePattern2";

    string ThisObject;
    BulletTrans BT;
    float _WorldHP;



    float RandomSummon;
    float _currentTime;
    float _WorldTime;

    #region
    bool _FirstSummon;
    bool _Patun; // 페턴중이냐 자체의 유무
    bool _SummonPaton; //한마리만 소환해야됨;
    bool _SecondSummon;
    #endregion

    void Start()
    {
        _SummonPaton = false;
        _FirstSummon = false;
        _SecondSummon = false;
        _Patun = false;
        _currentTime = 0;
        _WorldTime = 0;
        
    }

    public float GetWorldTime()
    {
        return _WorldHP;
    }

    public void SetNextPatton()
    {
        _WorldHP = 0;
        _WorldTime += 10;
        _Patun = false;
        _FirstSummon = false;
        _SecondSummon = false;
        _SummonPaton = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (_WorldTime > 3) // 시작 할때 UI 보여줄 시간
        {       // Debug.Log(_WorldTime);
            if (_Patun == false)
            {
                if (_FirstSummon == false)
                {
                    _FirstSummon = true;
                    StartCoroutine(MonsterSummonCrazy());

                }
                if (_SecondSummon == false)
                {
                    _SecondSummon = true;
                    if (_WorldTime >= 20f)
                    {
                        StartCoroutine(MonsterSummonTurlet());
                        StartCoroutine(MonsterSummonJimball());
                    }
                   
                }

                // 15초 에 미니보스 하나


            }
            if (40f > _WorldTime && _WorldTime >= 30f)
            {
                if (_SummonPaton == false)
                {
                    _SummonPaton = true;
                    StartCoroutine(FirstPatton());
                }

                _Patun = true;
                _WorldTime = 31f;
            }
            _WorldHP = _WorldTime / 2f;

            if (70f > _WorldTime && _WorldTime >= 60)
            {
                if (_SummonPaton == false)
                {
                    _SummonPaton = true;
                    BT = PoolManager.Instance.Pop(Patten2);
                    BT.transform.position = new Vector3(-3, 7, 0);

                    BT.transform.DOMove(new Vector3(-3, 3, 0), 2f);
                }
                _Patun = true;
                _WorldTime = 61f;
            }

        }


        _currentTime += Time.deltaTime;
        _WorldTime += Time.deltaTime;
        */
    }

    IEnumerator FirstPatton()
    {
        yield return new WaitForSeconds(3f);
        BT = PoolManager.Instance.Pop(Patten1);
        BT.transform.position = new Vector3(-3, 5, 0);
        BT.transform.DOMove(new Vector3(-3, 3, 0), 2f);
    }
    IEnumerator MonsterSummonCrazy()
    {
        while (true)
        {

            RandomSummon = UnityEngine.Random.Range(0f, -6.5f);
            switch (UnityEngine.Random.Range(0,2))
            {
                case 0:
                    BT = PoolManager.Instance.Pop(CBType1) as CrazyBirdType;
                    BT.transform.position = new Vector3(RandomSummon, 6.99f, 0);
                    BT.SetHp(20f + _WorldHP);
                    break;
                case 1:
                    if (_WorldTime >= 15f)
                    {
                        BT = PoolManager.Instance.Pop(CBType2) as CrazyBirdType;
                        BT.transform.position = new Vector3(RandomSummon, 6.99f, 0);
                        BT.SetHp(20 + _WorldHP);
                    }
                    else
                    {
                        BT = PoolManager.Instance.Pop(CBType1) as CrazyBirdType;
                        BT.transform.position = new Vector3(RandomSummon, 6.99f, 0);
                        BT.SetHp(20 + _WorldHP);
                    }
                    break;
            }
            yield return new WaitForSeconds(1f);


            if (_Patun == true)
            {
                break;
            }
        }
    }
    IEnumerator MonsterSummonTurlet()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            switch(UnityEngine.Random.Range(0,3))
            {
                case 1:
                    BT = PoolManager.Instance.Pop(TuretType1) as TurletType;
                    break;
                case 2:
                    BT = PoolManager.Instance.Pop(TuretType2) as TurletType;
                    break;
                case 3:
                    BT = PoolManager.Instance.Pop(TuretType3) as TurletType;
                    break;
            }
            if (_Patun == true)
            {
                break;
            }
        }
        while(true)
        {
            yield return new WaitForSeconds(0.8f);
            switch (UnityEngine.Random.Range(1, 4))
            {
                case 1:
                    ThisObject = TuretType1;
                    break;
                case 2:
                    ThisObject = TuretType2;
                    break;
                case 3:
                    ThisObject = TuretType3;
                    break;
            }
            BT = PoolManager.Instance.Pop(ThisObject) as TurletType;
            if (_Patun == false)
            {
                break;
            }

        }
    }
    IEnumerator MonsterSummonJimball()
    {
        while (true)
        {
            BT = PoolManager.Instance.Pop(JBType) as JimBallType;
            RandomSummon = UnityEngine.Random.Range(0f, -6.5f);
            BT.transform.position = new Vector3(RandomSummon, 6.99f, 0);
            RandomSummon = UnityEngine.Random.Range(1, 5);
            switch ((int)RandomSummon)
            {
                case 1:
                    BT.SetDir(new Vector3(0.7f, 0, 0));
                    break;
                case 2:
                    BT.SetDir(new Vector3(-0.7f, 0, 0));
                    break;
                case 3:
                    BT.SetDir(new Vector3(-0.4f, 0, 0));
                    break;
                case 4:
                    BT.SetDir(new Vector3(0.4f, 0, 0));
                    break;
            }
            BT.SetHp(30 + _WorldHP);
            if (_Patun == true)
            {
                break;
            }
            yield return new WaitForSeconds(1.5f);
        }


    }


}
