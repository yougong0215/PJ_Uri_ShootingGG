using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrans : MonoBehaviour
{


    public void SetObj(GameObject Enemy, GameObject Bult)
    {

        if (Enemy.CompareTag("CrazyBird"))
        {
            gameObject.GetComponent<CrazyBirdType>().Type(Bult);
        }
    }



}
