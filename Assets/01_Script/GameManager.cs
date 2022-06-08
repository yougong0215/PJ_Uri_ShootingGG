using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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


        PoolManager.Instance = new PoolManager(transform); // ���Ӹ޴��� Ǯ�� �θ�� �ؼ� Ǯ�޴��� �̱��� ����
        foreach (BulletTrans p in _PoolList)
        {
            PoolManager.Instance.CreatePool(p, 1); // 40���� �̾Ƴ��°ǵ� �̰� ���߿� ���ϴ¸�ŭ�̰� �ٲپ����
        }
    }
}
