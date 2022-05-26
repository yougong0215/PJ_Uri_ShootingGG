using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generic : MonoBehaviour
{
    #region 
    int sans = 12;
    #endregion


    List<GameObject> list;
    private void Start()
    {
        
        /*
        LogNumber<int>(100);
        LogNumber<float>(10.0f);
        //LogNumber<GameObject>(new GameObject());
        LogNumber(100000.000001);
        LogNumber<string>("asdf");
        */

        LogNumber<Generic>(this);
    }
    public void LogNumber<T>(T obj) where T : MonoBehaviour
    {
        Debug.Log(obj.name);
    }
}
