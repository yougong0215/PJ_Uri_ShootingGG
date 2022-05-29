using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stage1 : MonoBehaviour
{
    const string CBType1 = "CrazyBirdType1";
    const string CBType2 = "CrazyBirdType2";
    const string JBType = "Jimball";
    const string TuretType = "Turlet";
    const string Patten1 = "StagePattern1";
    const string Patten2 = "StagePattern2";

    BulletTrans BT;
    
    


    float RandomSummon;
    float _currentTime;
    float _WorldTime;

    #region
    bool _FirstSummon;
    bool _Patun; // 페턴중이냐 자체의 유무
    bool _SummonPaton; //한마리만 소환해야됨;
    #endregion

    void Start()
    {
        _SummonPaton = false;
        _FirstSummon = false;
        _Patun = false;
        _currentTime = 0;
        _WorldTime = 12;
    }

    public void SetNextPatton()
    {
        _WorldTime += 15;
    }

    // Update is called once per frame
    void Update()
    {
        if (_WorldTime > 3) // 시작 할때 UI 보여줄 시간
        {       // Debug.Log(_WorldTime);
            if(_Patun == false)
            {
                if (_FirstSummon == false)
                {
                    _FirstSummon = true;
                    StartCoroutine(MonsterSummonFirst());
                }

                // 15초 에 미니보스 하나
               

            }
                if ( 30f >_WorldTime && _WorldTime >= 15f)
                {
                     if(_SummonPaton == false)
                     {
                        _SummonPaton = true;
                        BT = PoolManager.Instance.Pop(Patten1);
                        BT.transform.position = new Vector3(-3, 3, 0);
                        BT.transform.DOMove(new Vector3(-3, 3, 0), 2f);
                     }
                    
                    _Patun = true;
                    _WorldTime = 16f;
                }

        }

            Debug.Log(_WorldTime);
        
        _currentTime += Time.deltaTime;
        _WorldTime += Time.deltaTime;

    }
    IEnumerator MonsterSummonFirst()
    {
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                RandomSummon = UnityEngine.Random.Range(0f, -6.5f);
                BT = PoolManager.Instance.Pop(CBType1) as CrazyBirdType;
                BT.transform.position = new Vector3(RandomSummon, 6.99f, 0);
                BT.SetHp(10);
                yield return new WaitForSeconds(1.5f);
            }
            if(_Patun == true)
                break;
        }
    }


}
