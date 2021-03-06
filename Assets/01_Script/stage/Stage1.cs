using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
public class Stage1 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreUI;
    [SerializeField] TextMeshProUGUI HighScoreUI;
    [SerializeField] Image WhiteHP;
    [SerializeField] Image RedHP;
    [SerializeField] Image BlueHP;
    [SerializeField] BackgroundSound bgSound;
    const string CBType1 = "CrazyBirdType1";
    const string CBType2 = "CrazyBirdType2";
    const string JBType = "Jimball";
    const string TuretType1 = "TurletType1";
    const string TuretType2 = "TurletType2";
    const string TuretType3 = "TurletType3";
    const string Patten1 = "StagePattern1";
    const string Patten2 = "StagePattern2";
    const string MiddleBoss = "BaeYaBoss";
    const string IdonowType = "IDoNow";
    SceneData _SC;

    string ThisObject;
    BulletTrans BT;
    float _WorldHP;

    bool BossSound;
    int Score = 0;
    float RandomSummon;
    float _currentTime;
    float _WorldTime;

    public void PlusScore(int value)
    {
        Score += value;
    }
    public int GetScore()
    {
        return Score;
    }
    public float GetGameTime()
    {
        return _currentTime;
    }
    #region
    bool _FirstSummon;
    bool _Patun; // 페턴중이냐 자체의 유무
    bool _SummonPaton; //한마리만 소환해야됨;
    bool _SecondSummon;
    #endregion
    float StageDiff;
    int _PattonInt;
    void Start()
    {
        _SC = GameObject.Find("StartData").GetComponent<SceneData>();
        BossSound = false;
        GameManager.Instance.HPBarOff();
        WhiteHP.fillAmount = 0;
        RedHP.fillAmount = 0;
        BlueHP.fillAmount = 0;
        _SummonPaton = false;
        _FirstSummon = false;
        _SecondSummon = true;
        _Patun = false;
        _currentTime = 0;
        _WorldTime = 0;
        if(_SC.GetDiff() == 1)
        {
            StageDiff = 2;
        }
        if(_SC.GetDiff() == 2)
        {
            StageDiff = 1;
        }
        if(_SC.GetDiff() == 3)
        {
            StageDiff = 0.5f;
        }
        HighScoreUI.text = $"HighScore : {PlayerPrefs.GetInt("HighScore", 0)}";
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
                StartCoroutine(MonsterSummonCrazy(1f, 30/StageDiff));
                StartCoroutine(MonsterSummonTurlet(5f));
                StartCoroutine(MonsterSummonJimball(2f, 50 / StageDiff));
                break;
            case 2:
                StopAllCoroutines();
                StartCoroutine(MonsterSummonCrazy(3f, 30 / StageDiff));
                StartCoroutine(MonsterSummonTurlet(1.5f * StageDiff));
                StartCoroutine(MonsterSummonJimball(4f, 50 / StageDiff));
                StartCoroutine(IdoNOwSummon(6, 30 / StageDiff));
                break;
            case 3:
                WhiteHP.fillAmount = 0;
                RedHP.fillAmount = 0;
                
                GameManager.Instance.ActiveFalseBulletOBJ();
                GameManager.Instance.HPBarOff();
                StopAllCoroutines();
                StartCoroutine(MonsterSummonCrazy(3f, 50 / StageDiff));
                StartCoroutine(MonsterSummonTurlet(5f));
                StartCoroutine(MonsterSummonJimball(5f, 70 / StageDiff));
                StartCoroutine(NonPatton(CBType2));
                StartCoroutine(IdoNOwSummon(6, 30 / StageDiff));
                break;
        }






    }
    private void LateUpdate()
    {
        PlayerPrefs.SetInt("Score", Score);
        ScoreUI.text = $"Score : {Score}";

        if(PlayerPrefs.GetInt("HighScore", 0)< PlayerPrefs.GetInt("Score",0))
        {
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score", 0));
            HighScoreUI.text = $"HighScore : {PlayerPrefs.GetInt("HighScore", 0)} Break!!";
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (_WorldTime > 3) // 시작 할때 UI 보여줄 시간
        {
            //Debug.Log(_WorldTime);
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
                    StartCoroutine(Patton(Patten1, 1, 3));
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
                    StartCoroutine(Patton(Patten2, 2, 3));
                }
                _Patun = true;
                _WorldTime = 61f;
            }

            if (130f > _WorldTime && _WorldTime >= 100)
            {
                if (_SummonPaton == false)
                {
                    StopAllCoroutines();  
                    _SummonPaton = true;
                    BossSound = true;
                    StartCoroutine(Patton(MiddleBoss, 3, 3));
                }
                _Patun = true;
                _WorldTime = 101;
            }



        }


        _currentTime += Time.deltaTime;
        _WorldTime += Time.deltaTime;
        
    }

    public bool BossComeing()
    {
        return BossSound;
    }
    public void BossGone(bool a)
    {
        BossSound = a;
    }

    IEnumerator Patton(string obj, int i, float pos)
    {
        GameManager.Instance.AudioReturn(3);
        yield return new WaitForSeconds(4f);
        BT = PoolManager.Instance.Pop(obj);
        
        
        BT.transform.position = new Vector3(-4, 6, 0);
        if (obj != MiddleBoss)
        {
            BT.transform.DOMove(new Vector3(-pos, 3, 0), 2f);
        }
        else
        {
            bgSound.TalkingStart(MiddleBoss);
        }
        _PattonInt = i;
    }
    IEnumerator NonPatton(string obj)
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            Debug.Log("던다");
            float h = Random.Range(-6.5f, 1f);
            for (int i = 0; i < 30; i++)
            {
                BT = PoolManager.Instance.Pop(obj);
                BT.SetHp(100);
                BT.StaticSetDir(Vector2.zero);
                if (i % 2 == 0)
                    BT.transform.position = new Vector3(Random.Range(h - 0.5f, h + 0.5f), 5, 0);
                else
                    BT.transform.position = new Vector3(Random.Range(h - 0.5f, h + 0.5f), -5, 0);

                if (i % 2 == 0)
                    StartCoroutine(BDUp1(BT));
                else
                    StartCoroutine(BDUp2(BT));
            }
        }
    }
    IEnumerator BDUp1(BulletTrans obj)
    {
        obj.transform.DOMoveY(5, 0.5f);
        yield return new WaitForSeconds(Random.Range(0.5f,1f));
        obj.transform.DOMoveY(-7, Random.Range(1f, 8f)).OnComplete(()=>
        {
            PoolManager.Instance.Push(obj);
        });
    }
    IEnumerator BDUp2(BulletTrans obj)
    {
        obj.transform.DOMoveY(-5, 0.5f);
        yield return new WaitForSeconds(Random.Range(0.5f, 1f));
        obj.transform.DOMoveY(7, Random.Range(1f, 8f)).OnComplete(() =>
        {
            PoolManager.Instance.Push(obj);
        });
    }


    IEnumerator IdoNOwSummon(float sec, float hp)
    {
        while (true)
        {

            RandomSummon = UnityEngine.Random.Range(-6.5f, 1.5f);

                    BT = PoolManager.Instance.Pop(IdonowType) as IDoNowType;
                    BT.transform.position = new Vector3(RandomSummon, 6.99f, 0);
                    BT.SetHp(hp + _WorldHP);
            yield return new WaitForSeconds(sec);
        }
    }
    IEnumerator MonsterSummonCrazy(float sec, float hp)
    {
        while (true)
        {

            RandomSummon = UnityEngine.Random.Range(-6.5f, 1.5f);
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
            RandomSummon = UnityEngine.Random.Range(-6.5f, 1.5f);
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
