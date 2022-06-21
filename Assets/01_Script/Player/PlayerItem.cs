using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    const string Ult = "Ult_Item";
    const string Power = "Power_Item";
    const string BigPower = "Big_Power_Item";

    PowerItem Pitem;

    private void Start()
    {
        PowerCnt = 100;
    }
    int PowerCnt;
    int LastCnt;

    public void HitPowerCnt()
    {
        LastCnt = PowerCnt;
        PowerCnt /= 2;
        LastCnt = LastCnt - PowerCnt;
        for(int i = 0; i < LastCnt/2;)
        {
            if(LastCnt - 5 >= 10)
            {
                Pitem = PoolManager.Instance.Pop(BigPower) as PowerItem;
                Pitem.transform.position += new Vector3(0, 2f, 0);
                Pitem.Pl();
                i += 5;
            }
            else
            {
                Pitem =  PoolManager.Instance.Pop(Power) as PowerItem;
                Pitem.transform.position += new Vector3(0, 2f, 0);
                Pitem.Pl();
                i++;
            }
        }
    }
    public int GetPowerCnt()
    {
        return PowerCnt;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == Ult)
        {
            Debug.Log("¾óÆ®");
        }
        if (collision.name == Power)
        {
            PowerCnt++;
        }
        if(collision.name == BigPower)
        {
            PowerCnt += 5;
        }
    
    }
}
