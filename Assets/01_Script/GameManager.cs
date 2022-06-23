using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    AudioSource _AudioPlay;
    GameObject MiddleBoss;
    Image WhiteHP;
    Image RedHP;
    Image HPBar;
    Transform Player;
    TextMeshProUGUI TalkText;
    Image _Panel;

    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    instance = new GameObject().AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }
    [SerializeField] private List<BulletTrans> _PoolList;

    private void Awake()
    {
        /*
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        */
        _Panel = GameObject.Find("Canvas/TalkPanel").GetComponent<Image>();
        TalkText = GameObject.Find("Canvas/TalkPanel/Talk").GetComponent<TextMeshProUGUI>();
        _AudioPlay = GetComponent<AudioSource>();
        WhiteHP = GameObject.Find("Canvas/Pase1").GetComponent<Image>();
        RedHP = GameObject.Find("Canvas/Pase2").GetComponent<Image>();
        HPBar = GameObject.Find("Canvas/HPBar").GetComponent<Image>();
        Player = GameObject.Find("Player").GetComponent<Transform>();
        PoolManager.Instance = new PoolManager(transform); // 게임메니저 풀링 부모로 해서 풀메니저 싱글톤 생성
        foreach (BulletTrans p in _PoolList)
        {
            PoolManager.Instance.CreatePool(p, 1); // 40개씨 뽑아내는건데 이건 나중에 원하는만큼뽑게 바꾸어ㅑ됨
        }
        _Panel.rectTransform.localPosition = new Vector3(280, -1000, 0);
    }
    private void Start()
    {
    }
    public Image TextPanel()
    {
        return _Panel;
    }
    public TextMeshProUGUI TextGUI()
    {
        return TalkText;
    }
    
    [SerializeField] private List<AudioClip> _audio;
    public void AudioReturn(int i)
    {
        _AudioPlay.PlayOneShot(_audio[i]);
    }

    public AudioClip AudioPlay(int i)
    {
        return _audio[i];
    }
         
    public Transform PlayerPos()
    {
        return Player;
    }

    public void ActiveFalseBulletOBJ()
    {
        GameManager obj = null;
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    public void HPBarOn()
    {
        HPBar.fillAmount = 1;
    }
    public void HPBarOff()
    {
        HPBar.fillAmount = 0;
    }

    public Image GetWhiteImage()
    {
        return WhiteHP;
    }
    public Image GetRedImage()
    {
        return RedHP;
    }
}
