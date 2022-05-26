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
        PoolManager.Instance = new PoolManager(transform); // ���Ӹ޴��� Ǯ�� �θ�� �ؼ� Ǯ�޴��� �̱��� ����
        foreach (BulletTrans p in _PoolList)
        {
            PoolManager.Instance.CreatePool(p, 40); // 40���� �̾Ƴ��°ǵ� �̰� ���߿� ���ϴ¸�ŭ�̰� �ٲپ����
        }
        damaged = false;
    }
}
