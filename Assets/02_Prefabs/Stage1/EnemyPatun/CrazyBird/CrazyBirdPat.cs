using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyBirdPat : MonoBehaviour
{
    float rotSpeed;
    
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 100 * Time.deltaTime));
        for (int i = 0; transform.childCount > i; i++)
        {
            transform.GetChild(i).transform.Rotate(new Vector3(0, 0, -1 * 100 * Time.deltaTime));
        }
    }
}
