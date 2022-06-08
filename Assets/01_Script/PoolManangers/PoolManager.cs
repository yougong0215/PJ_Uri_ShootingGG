using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    public static PoolManager Instance;

    private GameObject _Item;

    private Dictionary<string, Pool<BulletTrans>> _pools = new Dictionary<string, Pool<BulletTrans>>();

    private Transform _trmParent;

    public PoolManager(Transform trmParent)
    {
        _trmParent = trmParent;
    }
    public void CreatePool(BulletTrans prefab, int cnt = 5)
    {
        Pool<BulletTrans> pool = new Pool<BulletTrans>(prefab, _trmParent, cnt);
        _pools.Add(prefab.gameObject.name, pool);
    }

    public BulletTrans Pop(string prefabName)
    {
        if (_pools.ContainsKey(prefabName) == false)
        {
            Debug.LogError("ÇÁ¸®Æé¾øµ¥");
            return null;
        }


        BulletTrans item = _pools[prefabName].Pop();
        item.Reset();
        return item;
    }


    public void Push(BulletTrans obj)
    {
        _pools[obj.name].Push(obj);
    }
}
