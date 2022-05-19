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


    private PoolManager poolManager = null;

    public PoolManager PoolManagerpro
    {
        get
        {
            if (poolManager == null)
            {
                poolManager = FindObjectOfType<PoolManager>();
            }
            return poolManager;
        }
    }

    private BluePullManager bluepoolManager = null;

    public BluePullManager bluePoolManagerpro
    {
        get
        {
            if (bluepoolManager == null)
            {
                bluepoolManager = FindObjectOfType<BluePullManager>();
            }
            return bluepoolManager;
        }
    }

    private
    void awake()
    {
        if (InstancePro != null && InstancePro != this)
        {
            Destroy(gameObject);
        }


    }

    public void Despawn(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(PoolManagerpro.gameObject.transform);
    }
    public void BlueDespawn(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(bluePoolManagerpro.gameObject.transform);
    }
}
