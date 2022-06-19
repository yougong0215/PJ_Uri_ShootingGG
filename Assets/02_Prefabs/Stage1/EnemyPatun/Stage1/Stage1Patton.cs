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
        
        HP = 10000;
        STG = GameObject.Find("Stage1").GetComponent<Stage1>();
    }
    private void OnEnable()
    {
        for (int i = 0; transform.childCount > i; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
            transform.GetChild(i).gameObject.GetComponent<BulletTrans>().SetHp(GetWorldTime() + 50);
        }
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
        
        if (gameObject.name == Patten1 || gameObject.name == Patten2)
        {
            rotSpeed = Random.Range(100,300);
            
            for (int i = 0; transform.childCount > i; i++)
            {
                transform.GetChild(i).transform.Rotate(new Vector3(0, 0, -1 * rotSpeed * Time.deltaTime));
            }
            transform.Rotate(new Vector3(0, 0, rotSpeed * Time.deltaTime));
        } 



        
    }
    private void LateUpdate()
    {
        int j = 0;
        for (int i = 0; transform.childCount > i; i++)
        {

            if (transform.GetChild(i).gameObject.activeSelf == false)
            {
                j++;
            }
            if (j == transform.childCount)
            {
                SetNextPatton();
                PoolManager.Instance.Push(this);
            }

        }
    }

    public override void Reset()
    {
    }
}
