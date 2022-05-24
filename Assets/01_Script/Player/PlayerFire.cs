using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    PlayerItem playeritem;
    int bulletCnt;
    int Version;
      BulletTrans Bullet;
    PlayerBullet PBullet;
    

    private void Start()
    {
        playeritem = GameObject.Find("Player").GetComponent<PlayerItem>();
        StartCoroutine(Delay());
    }
  

    private void Update()
    {
    }


    IEnumerator Delay()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            if (playeritem.GetPowerCnt() == 0)
            {
                bulletCnt = 1;
                Version = 1;
            }
            else if(playeritem.GetPowerCnt() <= 1)
            {
                bulletCnt = 3;
                Version = 2;
            }

            Shoot();
        }
    }
    void Shoot()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            for (; bulletCnt > 0; bulletCnt--)
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
                PBullet.SetType(Version, bulletCnt);
                
                Bullet.transform.position = transform.position;
            }
        }
    }


}
