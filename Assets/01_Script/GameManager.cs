using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance = null;
    public static GameManager InstancePro
    {
        get
        {
            if (Instance == null)
            {
                Instance = FindObjectOfType<GameManager>();
                if (Instance == null)
                {
                    Instance = new GameObject().AddComponent<GameManager>();

                    DontDestroyOnLoad(Instance);
                }
            }
            return Instance;
        }
    }


    [SerializeField] private List<BulletTrans> _PoolList;


    private void Awake()
    {
        PoolManager.Instance = new PoolManager(transform); // 게임메니저 풀링 부모로 해서 풀메니저 싱글톤 생성
        foreach (BulletTrans p in _PoolList)
        {
            PoolManager.Instance.CreatePool(p, 40); // 40개씨 뽑아내는건데 이건 나중에 원하는만큼뽑게 바꾸어ㅑ됨
        }
    }
}
