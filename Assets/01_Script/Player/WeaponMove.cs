using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMove : MonoBehaviour
{

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector2(0, 1f), 0.05f);
        }
        else
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector2(0, -0.75f), 0.05f);
        }
    }
}
