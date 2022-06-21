using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   

    Image WhiteHP;
    Image RedHP;
    Image HPBar;
    Transform Player;
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

        WhiteHP = GameObject.Find("Canvas/Pase1").GetComponent<Image>();
        RedHP = GameObject.Find("Canvas/Pase2").GetComponent<Image>();
        HPBar = GameObject.Find("Canvas/HPBar").GetComponent<Image>();


        PoolManager.Instance = new PoolManager(transform); // 게임메니저 풀링 부모로 해서 풀메니저 싱글톤 생성
        foreach (BulletTrans p in _PoolList)
        {
            PoolManager.Instance.CreatePool(p, 1); // 40개씨 뽑아내는건데 이건 나중에 원하는만큼뽑게 바꾸어ㅑ됨
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
