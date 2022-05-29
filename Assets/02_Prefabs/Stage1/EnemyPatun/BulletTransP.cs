using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTransP : BulletTrans
{
    Stage1 STG1;

    void Awake()
    {
        STG1 = gameObject.GetComponent<Stage1>();
    }
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

    public void Push()
    {
        PoolManager.Instance.Push(this);
        STG1.SetNextPatton();
    }



    protected override void OnTriggerEnter2D(Collider2D collision)
    {
    }
}
