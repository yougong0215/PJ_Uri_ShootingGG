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
        PoolManager.Instance = new PoolManager(transform); // ���Ӹ޴��� Ǯ�� �θ�� �ؼ� Ǯ�޴��� �̱��� ����
        foreach (BulletTrans p in _PoolList)
        {
            PoolManager.Instance.CreatePool(p, 40); // 40���� �̾Ƴ��°ǵ� �̰� ���߿� ���ϴ¸�ŭ�̰� �ٲپ����
        }
    }
}
