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
    AudioSource _audio;
    SceneData _SC;


    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        playeritem = GameObject.Find("Player").GetComponent<PlayerItem>();
        StartCoroutine(Delay());
        _SC = GameObject.Find("StartData").GetComponent<SceneData>();
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
        if (Input.GetKeyUp(KeyCode.Z) && gameObject.name == "Dark")
        {
            _audio.Stop();
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
        if (_SC.GetModeData() != 3)
        {
            
                if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Return))
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
                    if (_SC.GetDiff() == 1)
                    {
                        Damage *= 2;
                    }
                    PBullet.SetType(Version, bulletCnt, Damage);
                        PBullet.transform.position = transform.position;
                    }
                    if (gameObject.name == "Dark")
                    {
                        _audio.Play();
                    }

                }
            
        }
    }
}

