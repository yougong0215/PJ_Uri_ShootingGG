using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTransP : BulletTrans
{
    int i;
    public override void Reset()
    {
        i = 0;
    }
    private void OnEnable()
    {
        for(i = 0; transform.childCount > i; i++ )
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        for(i = 0; transform.childCount > i; i++)
        {
            int j = 0;
            
            if(transform.GetChild(i).gameObject.activeSelf == false)
            {
                j++;
            }
            if(j == transform.childCount)
            {
                PoolManager.Instance.Push(this);
            }
        }
    }



    protected override void OnTriggerEnter2D(Collider2D collision)
    {
    }
}
