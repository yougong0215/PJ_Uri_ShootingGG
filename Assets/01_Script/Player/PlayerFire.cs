using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    PlayerItem playeritem;
    int bulletCnt;
    int Version;
    PlayerBullet PBullet;
    float speed;
    float Damage;
    int bulletMax;
    


    private void Start()
    {
        playeritem = GameObject.Find("Player").GetComponent<PlayerItem>();
        StartCoroutine(Delay());
    }


    private void Update()
    {
        if (playeritem.GetPowerCnt() >= -10 && playeritem.GetPowerCnt() < 3)
        {
            bulletCnt = 1;
            Version = 1;
            speed = 0.2f;
            Damage = 1;
            bulletMax = 1;
        }
        else if (playeritem.GetPowerCnt() >= 3 && playeritem.GetPowerCnt() <= 7)
        {
            bulletMax = 1;
            bulletCnt = 1;
            Version = 1;
            speed = 0.2f;
            Damage = 2;
        }
        else if (playeritem.GetPowerCnt() > 7 && playeritem.GetPowerCnt() <= 15)
        {
            bulletMax = 2;
            bulletCnt = 2;
            Version = 2;
            speed = 0.2f;
            Damage = 2;
        }
        else if (playeritem.GetPowerCnt() > 15 && playeritem.GetPowerCnt() <= 20)
        {
            bulletMax = 2;
            bulletCnt = 2;
            Version = 2;
            speed = 0.2f;
            Damage = 2f;
        }
        else if (playeritem.GetPowerCnt() > 20 && playeritem.GetPowerCnt() <= 40)
        {
            bulletMax = 3;
            bulletCnt = 3;
            Version = 3;
            speed = 0.2f;
            Damage = 2.5f;
        }
        else if (playeritem.GetPowerCnt() > 40 && playeritem.GetPowerCnt() <= 60)
        {
            bulletMax = 3;
            bulletCnt = 3;
            Version = 3;
            speed = 0.2f;
            Damage = 3f;
        }
        else if (playeritem.GetPowerCnt() > 60 && playeritem.GetPowerCnt() <= 80)
        {
            bulletMax = 4;
            bulletCnt = 4;
            Version = 4;
            speed = 0.15f;
            Damage = 2f;
        }
        else if (playeritem.GetPowerCnt() > 80 && playeritem.GetPowerCnt() < 100)
        {
            bulletMax = 4;
            bulletCnt = 4;
            Version = 4;
            speed = 0.10f;
            Damage = 2f;
        }
        else if (playeritem.GetPowerCnt() >= 100)
        {
            bulletMax = 5;
            bulletCnt = 5;
            Version = 5;
            speed = 0.05f;
            Damage = 2f;
        }
    }


    IEnumerator Delay()
    {
        while (true)
        {

            yield return new WaitForSeconds(speed);
            Shoot();
        }
    }
    void Shoot()
    {
        

        if (Input.GetKey(KeyCode.Z))
        {
            for (bulletCnt = bulletMax; bulletCnt > 0; bulletCnt--)
            {

                if (gameObject.name == "Dark")
                {
                    PBullet = PoolManager.Instance.Pop("DarkArr") as PlayerBullet;

                }
                else if (gameObject.name == "Light")
                {
                    PBullet = PoolManager.Instance.Pop("LightArr") as PlayerBullet;
                }
                PBullet.SetType(Version, bulletCnt, Damage);
                PBullet.transform.position = transform.position;
            }


        }
    }
}

