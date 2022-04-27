using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingAttack : MonoBehaviour
{
    public GameObject Wing;
    public GameObject[] WingObjects;
    private int pivot = 0;
    bool Attack =false;

    void Start()
    {
        WingObjects = new GameObject[10];
        for(int i =0; i < 10; i++)
        {
            GameObject WingObj = Instantiate(Wing);
            WingObjects[i] = WingObj;
            WingObj.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetButtonUp("Jump"))
        {
            StartCoroutine("EnableWing");
        }
    }

    IEnumerator EnableWing()
    {
        yield return new WaitForSeconds(0.1f);
        WingObjects[pivot].SetActive(true);
        WingObjects[pivot].transform.position = transform.position;
            pivot++;
        
        if (pivot == 10) pivot = 0;
    }
}


