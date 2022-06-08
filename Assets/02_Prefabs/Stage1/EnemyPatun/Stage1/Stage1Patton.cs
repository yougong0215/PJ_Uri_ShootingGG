using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stage1Patton : BulletTrans
{
    float rotSpeed;
    [SerializeField ]Stage1 STG;
    
    float ObjectRotZ;
    Vector3 ObjectRot;


    const string Patten1 = "StagePattern1";
    const string Patten2 = "StagePattern2";
    void Awake()
    {
        STG = GameObject.Find("Stage1").GetComponent<Stage1>();
    }
    // Update is called once per frame
    public void SetNextPatton()
    {
        STG.SetNextPatton();
    }
    public float GetWorldTime()
    {
        return STG.GetWorldTime();
    }
    void Update()
    {
        if (gameObject.name == Patten1)
        {
            rotSpeed = 100;
            
            for (int i = 0; transform.childCount > i; i++)
            {
                transform.GetChild(i).transform.Rotate(new Vector3(0, 0, -1 * rotSpeed * Time.deltaTime));
            }
            transform.Rotate(new Vector3(0, 0, rotSpeed * Time.deltaTime));
        } 
        else if(gameObject.name == Patten2)
        {
            rotSpeed = 500;
            for (int i = 0; transform.childCount > i; i++)
            {
                Transform transformChild = transform.GetChild(i);
                if (transform.GetChild(0).gameObject.activeSelf == false)
                {
                    rotSpeed = 300;
                    transform.GetChild(i).transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
                    //transform.GetChild(2).transform.position += new Vector3(0, 1, 0) * Time.deltaTime;
                    //transform.GetChild(3).transform.position += new Vector3(-1, 0, 0) * Time.deltaTime;
                    //transform.GetChild(4).transform.position += new Vector3(0, -1, 0) * Time.deltaTime;

                    transform.Rotate(new Vector3(0, 0, -rotSpeed * Time.deltaTime));
                    transform.DOMoveY(10f, 5f).Kill();
                }
                    transformChild.transform.Rotate(new Vector3(0, 0, -1 * rotSpeed * Time.deltaTime));
                   
            }
            transform.Rotate(new Vector3(0, 0, rotSpeed * Time.deltaTime));

        }
        
    }

    public override void Reset()
    {
    }
}
