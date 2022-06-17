using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Stage1 : MonoBehaviour
{

    [SerializeField] Image WhiteHP;
    [SerializeField] Image RedHP;

    const string CBType1 = "CrazyBirdType1";
    const string CBType2 = "CrazyBirdType2";
    const string JBType = "Jimball";
    const string TuretType1 = "TurletType1";
    const string TuretType2 = "TurletType2";
    const string TuretType3 = "TurletType3";
    const string Patten1 = "StagePattern1";
    const string Patten2 = "StagePattern2";
    const string MiddleBoss = "BaeYaBoss";

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
    int _PattonInt;
    void Start()
    {
        WhiteHP.fillAmount = 0;
        RedHP.fillAmount = 0;
        _SummonPaton = false;
        _FirstSummon = false;
        _SecondSummon = true;
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
        _SummonPaton = false;
        switch (_PattonInt)
        {
            case 1:
                StopAllCoroutines();
                StartCoroutine(MonsterSummonCrazy(1f, 30));
                StartCoroutine(MonsterSummonTurlet(5f));
                StartCoroutine(MonsterSummonJimball(2f, 50));
                
                break;
            case 2:
                StopAllCoroutines();
                StartCoroutine(MonsterSummonCrazy(1f, 50));
                StartCoroutine(MonsterSummonTurlet(4f));
                StartCoroutine(MonsterSummonJimball(2f, 80));
                break;
            case 3:
                WhiteHP.fillAmount = 0;
                RedHP.fillAmount = 0;
                break;
        }






    }

    // Update is called once per frame
    void Update()
    {


        
        if (_WorldTime > 3) // 시작 할때 UI 보여줄 시간
        {
            Debug.Log(_WorldTime);
            if (_FirstSummon == false)
            {
                _FirstSummon = true;
                StartCoroutine(MonsterSummonCrazy(1.5f, 5));
                StartCoroutine(MonsterSummonJimball(2.5f, 5));

            }

            if (40f > _WorldTime && _WorldTime >= 30f)
            {
                if (_SummonPaton == false)
                {
                    StopAllCoroutines();
                    _SummonPaton = true;
                    StartCoroutine(Patton(Patten1,1));
                }

                _Patun = true;
                _WorldTime = 31f;
            }
            _WorldHP = _WorldTime / 2f;

            if (70f > _WorldTime && _WorldTime >= 60)
            {
                if (_SummonPaton == false)
                {
                    StopAllCoroutines();
                    _SummonPaton = true;
                    BT = PoolManager.Instance.Pop(Patten2);
                }
                _Patun = true;
                _WorldTime = 61f;
            }

            if (110f > _WorldTime && _WorldTime >= 100)
            {
                if (_SummonPaton == false)
                {
                    StopAllCoroutines();
                    _SummonPaton = true;
                    BT = PoolManager.Instance.Pop(MiddleBoss);
                }
                _Patun = true;
                _WorldTime = 101;
            }

        }


        _currentTime += Time.deltaTime;
        _WorldTime += Time.deltaTime * 3;
        
    }

    IEnumerator Patton(string obj, int i)
    {
        yield return new WaitForSeconds(3f);
        BT = PoolManager.Instance.Pop(obj);
        BT.transform.position = new Vector3(-3, 6, 0);
        BT.transform.DOMove(new Vector3(-3, 3, 0), 2f);
        _PattonInt = i;
    }



    IEnumerator MonsterSummonCrazy(float sec, float hp)
    {
        while (true)
        {

            RandomSummon = UnityEngine.Random.Range(0f, -6.5f);
            switch (UnityEngine.Random.Range(0,2))
            {
                case 0:
                    BT = PoolManager.Instance.Pop(CBType1) as CrazyBirdType;
                    BT.transform.position = new Vector3(RandomSummon, 6.99f, 0);
                    BT.SetHp(hp + _WorldHP);
                    break;
                case 1:
                    if (_WorldTime >= 15f)
                    {
                        BT = PoolManager.Instance.Pop(CBType2) as CrazyBirdType;
                        BT.transform.position = new Vector3(RandomSummon, 6.99f, 0);
                        BT.SetHp(hp + _WorldHP);
                    }
                    else
                    {
                        BT = PoolManager.Instance.Pop(CBType1) as CrazyBirdType;
                        BT.transform.position = new Vector3(RandomSummon, 6.99f, 0);
                        BT.SetHp(hp + _WorldHP);
                    }
                    break;
            }
            yield return new WaitForSeconds(sec);
        }
    }
    IEnumerator MonsterSummonTurlet(float sec)
    {
        while (_Patun == false)
        {
            yield return new WaitForSeconds(sec);
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

            if(_Patun == false)
            {
                break;
            }
        }
    }
    IEnumerator MonsterSummonJimball(float sec  , float hp)
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
            BT.SetHp(hp + _WorldHP);
            yield return new WaitForSeconds(sec);
        }


    }


}
