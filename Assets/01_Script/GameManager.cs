using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager Instancet = null;
    public static GameManager Instance
    {
        get
        {
            if (Instancet == null)
            {
                Instancet = FindObjectOfType<GameManager>();
                if (Instancet == null)
                {
                    Instancet = new GameObject().AddComponent<GameManager>();

                    DontDestroyOnLoad(Instancet);
                }
            }
            return Instancet;
        }
    }
    private bool damaged;
    public void SetDamaged(bool value) { damaged = value; }
    public bool GetDamaged() { return damaged; }

    [SerializeField] private List<BulletTrans> _PoolList;


    private void Awake()
    {
        PoolManager.Instance = new PoolManager(transform); // 게임메니저 풀링 부모로 해서 풀메니저 싱글톤 생성
        foreach (BulletTrans p in _PoolList)
        {
            PoolManager.Instance.CreatePool(p, 40); // 40개씨 뽑아내는건데 이건 나중에 원하는만큼뽑게 바꾸어ㅑ됨
        }
        damaged = false;
    }
}
