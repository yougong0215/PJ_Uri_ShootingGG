using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItem : MonoBehaviour
{
    const string Ult = "Ult_Item";
    const string Power = "Power_Item";
    const string BigPower = "Big_Power_Item";
    [SerializeField] Image Gage;
    PowerItem Pitem;

    private void Start()
    {
        PowerCnt = 0;
    }
    float PowerCnt;
    int LastCnt;

    private void Update()
    {
        if(PowerCnt <= 0 )
        {
            PowerCnt = 0;
        }
        if (PowerCnt >= 100)
        {
            PowerCnt = 100;
        }
        Gage.fillAmount = PowerCnt / 100;
    }
    public void HitPowerCnt()
    {
        LastCnt = (int)PowerCnt;
        PowerCnt /= 2;
        LastCnt = LastCnt - (int)PowerCnt;
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
    public float GetPowerCnt()
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
