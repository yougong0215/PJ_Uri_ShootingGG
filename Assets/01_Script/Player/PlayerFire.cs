using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    PlayerItem playeritem;
    int bulletCnt;
    int bulletMa;
    int Version;
    BulletTrans Bullet;
    PlayerBullet PBullet;
    int speed;
    float Damage;


    private void Start()
    {
        playeritem = GameObject.Find("Player").GetComponent<PlayerItem>();
        StartCoroutine(Delay(speed));
    }


    private void Update()
    {
        if (playeritem.GetPowerCnt() == 0)
        {
            bulletCnt = 1;
            Version = 1;
            bulletMa = 1;

            Damage = 1;
        }
        else if (playeritem.GetPowerCnt() <= 1 && playeritem.GetPowerCnt() <= 3)
        {
            bulletCnt = 3;
            Version = 2;
            bulletMa = 3;

            Damage = 1;
        }
        else if (playeritem.GetPowerCnt() <= 3)
        {
            bulletCnt = 5;
            Version = 3;
            bulletMa = 5;

            Damage = 1;
        }
    }


    IEnumerator Delay(float sec)
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            Shoot();


        }
    }
    void Shoot()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            for (bulletCnt = bulletMa; bulletCnt > 0; bulletCnt--)
            {

                if (gameObject.name == "Dark")
                {
                    Bullet = PoolManager.Instance.Pop("DarkArr");

                }
                else if (gameObject.name == "Light")
                {
                    Bullet = PoolManager.Instance.Pop("LightArr");
                }
                PBullet = Bullet.GetComponent<PlayerBullet>();
                PBullet.SetType(Version, bulletCnt, Damage);
                Bullet.transform.position = transform.position;
            }


        }
    }
}

