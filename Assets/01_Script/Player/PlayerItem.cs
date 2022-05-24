using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    const string Ult = "Ult_Item";
    const string Power = "Power_Item";

    private void Start()
    {
        PowerCnt = 0;
    }
    int PowerCnt;

    
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
    
    }
}
