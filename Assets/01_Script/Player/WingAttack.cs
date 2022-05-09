using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingAttack : MonoBehaviour
{
    public GameObject Wing;
    public WingAtt_Pull[] WingObjects;
    [SerializeField] private WingAtt_Pull Wings;
    private int pivot = 0;
    float currentTime = 0f;

    void Start()
    {
        WingObjects = new WingAtt_Pull[10];
        for(int i =0; i < 10; i++)
        {
            WingAtt_Pull WingObj = Instantiate(Wing).GetComponent<WingAtt_Pull>();
            WingObjects[i] = WingObj;
            WingObj.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetButton("Jump"))
        {
            currentTime += Time.deltaTime;
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            for (int i = 0; i < 10; i++)
            {
                WingObjects[i].SetCurrentTime(currentTime);
            }
            StartCoroutine("EnableWing");
        }
    }

    IEnumerator EnableWing()
    {
        yield return new WaitForSeconds(0.1f);
        WingObjects[pivot].gameObject.SetActive(true);
        //currentTime = 0;
        WingObjects[pivot].transform.position = transform.position;
            pivot++;
        
        if (pivot == 10) pivot = 0;
    }
}


