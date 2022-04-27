using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletMaster : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject[] BulletObjects;
    private int pivot = 0;

    void Start()
    {
        BulletObjects = new GameObject[600];
        for(int i = 0; i < 600; i++)
        {
            GameObject BulletObj = Instantiate(Bullet);
            BulletObjects[i] = BulletObj;
            BulletObj.SetActive(false);
        }
        StartCoroutine("EnableBullet");
    }
    IEnumerator EnableBullet()
    {
        BulletObjects[pivot].transform.position = transform.position;
        yield return new WaitForSeconds(0.05f);
        BulletObjects[pivot].SetActive(true);
        BulletObjects[pivot].transform.position = transform.position;
        pivot++;
        if (pivot == 600) pivot = 0;
        StartCoroutine("EnableBullet");
    }

}
