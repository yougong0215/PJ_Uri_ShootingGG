using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTransP : BulletTrans
{
    Stage1Patton STG1;
    int j;
    void Awake()
    {
        STG1 = gameObject.GetComponent<Stage1Patton>();
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
            transform.GetChild(i).gameObject.GetComponent<BulletTrans>().SetHp(STG1.GetWorldTime()+50);
        }
    }

    private void Update()
    {
        j = 0;
        for (i = 0; transform.childCount > i; i++)
        {
            
            if(transform.GetChild(i).gameObject.activeSelf == false)
            {
                j++;
            }
            if(j == transform.childCount)
            {
                PoolManager.Instance.Push(this);
                STG1.SetNextPatton();
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
