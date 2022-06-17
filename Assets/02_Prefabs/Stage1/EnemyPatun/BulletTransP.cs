using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTransP : BulletTrans
{
    Stage1Patton STG1;
    int j;
    void Awake()
    {
        HP = 10000;
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



    protected void OnTriggerEnter2D(Collider2D collision)
    {
    }
}
