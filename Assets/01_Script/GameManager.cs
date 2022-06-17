using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   

    Image WhiteHP;
    GameObject _Canvas;
    Image RedHP;
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

        WhiteHP = GameObject.Find("Canvas/White").GetComponent<Image>();
        RedHP = GameObject.Find("Canvas/Red").GetComponent<Image>();
        PoolManager.Instance = new PoolManager(transform); // ���Ӹ޴��� Ǯ�� �θ�� �ؼ� Ǯ�޴��� �̱��� ����
        foreach (BulletTrans p in _PoolList)
        {
            PoolManager.Instance.CreatePool(p, 1); // 40���� �̾Ƴ��°ǵ� �̰� ���߿� ���ϴ¸�ŭ�̰� �ٲپ����
        }
        
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
