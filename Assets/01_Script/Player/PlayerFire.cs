using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    [SerializeField] TextMeshProUGUI _PowerCnt;
    [SerializeField] PlayerSwing Pswing;


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
            _PowerCnt.text = "LVL : [ 1 ]";
            if (_SC.GetModeData() == 2)
            {
                Damage = 0.01f;
            }
        }
        else if (playeritem.GetPowerCnt() >= 3 && playeritem.GetPowerCnt() <= 7)
        {
            bulletMax = 1;
            bulletCnt = 1;
            Version = 1;
            speed = 0.2f;
            Damage = 2;
            _PowerCnt.text = "LVL : [ 2 ]";
            if (_SC.GetModeData() == 2)
            {
                Damage = 0.03f;
            }
        }
        else if (playeritem.GetPowerCnt() > 7 && playeritem.GetPowerCnt() <= 15)
        {
            bulletMax = 2;
            bulletCnt = 2;
            Version = 2;
            speed = 0.2f;
            Damage = 2;
            _PowerCnt.text = "LVL : [ 3 ]";
            if (_SC.GetModeData() == 2)
            {
                Damage = 0.03f;
            }
        }
        else if (playeritem.GetPowerCnt() > 15 && playeritem.GetPowerCnt() <= 20)
        {
            bulletMax = 2;
            bulletCnt = 2;
            Version = 2;
            speed = 0.2f;
            Damage = 2f;
            _PowerCnt.text = "LVL : [ 4 ]";
            if (_SC.GetModeData() == 2)
            {
                Damage = 0.03f;
            }
        }
        else if (playeritem.GetPowerCnt() > 20 && playeritem.GetPowerCnt() <= 40)
        {
            bulletMax = 3;
            bulletCnt = 3;
            Version = 3;
            speed = 0.2f;
            Damage = 2.5f;
            if (_SC.GetModeData() == 2)
            {
                Damage = 0.05f;
            }
            _PowerCnt.text = "LVL : [ 5 ]";
        }
        else if (playeritem.GetPowerCnt() > 40 && playeritem.GetPowerCnt() <= 60)
        {
            bulletMax = 3;
            bulletCnt = 3;
            Version = 3;
            speed = 0.2f;
            Damage = 3f;
            _PowerCnt.text = "LVL : [ 6 ]";
            if (_SC.GetModeData() == 2)
            {
                Damage = 0.05f;
            }
        }
        else if (playeritem.GetPowerCnt() > 60 && playeritem.GetPowerCnt() <= 80)
        {
            bulletMax = 4;
            bulletCnt = 4;
            Version = 4;
            speed = 0.15f;
            Damage = 2f;
            _PowerCnt.text = "LVL : [ 7 ]";
            if (_SC.GetModeData() == 2)
            {
                Damage = 0.075f;
            }
        }
        else if (playeritem.GetPowerCnt() > 80 && playeritem.GetPowerCnt() < 100)
        {
            bulletMax = 4;
            bulletCnt = 4;
            Version = 4;
            speed = 0.10f;
            Damage = 2f;
            _PowerCnt.text = "LVL : [ 8 ]";
            if (_SC.GetModeData() == 2)
            {
                Damage = 0.075f;
            }
        }
        else if (playeritem.GetPowerCnt() >= 100)
        {
            bulletMax = 5;
            bulletCnt = 5;
            Version = 5;
            speed = 0.05f;
            Damage = 2f;
            if (_SC.GetModeData() == 2)
            {
                Damage = 0.1f;
            }
            _PowerCnt.text = "LVL : [MAX]";
        }
        if (Input.GetKeyUp(KeyCode.Z) && gameObject.name == "Dark")
        {
            _audio.Stop();
        }
        if (_SC.GetModeData() == 2)
        {
            speed = 0.02f;
            Damage *= 6;
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
                        PBullet.transform.position = transform.position;
                        
                        if (Pswing.GetSuperMofe() == true)
                        {
                            PBullet = PBullet = PoolManager.Instance.Pop("DarkArr") as PlayerBullet;
                            PBullet.transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y + 0.1f, 0);
                            PBullet = PBullet = PoolManager.Instance.Pop("DarkArr") as PlayerBullet;
                            PBullet.transform.position = new Vector3(transform.position.x + 0.25f, transform.position.y + 0.1f, 0);
                        }
                    }
                    else if (gameObject.name == "Light")
                    {
                        PBullet = PoolManager.Instance.Pop("LightArr") as PlayerBullet;
                        PBullet.transform.position = transform.position;
                        if (Pswing.GetSuperMofe() == true)
                        {
                            PBullet = PBullet = PoolManager.Instance.Pop("LightArr") as PlayerBullet;
                            PBullet.transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y + 0.1f, 0);
                            PBullet = PBullet = PoolManager.Instance.Pop("LightArr") as PlayerBullet;
                            PBullet.transform.position = new Vector3(transform.position.x + 0.25f, transform.position.y + 0.1f, 0);
                        }

                    }
                    if (_SC.GetDiff() == 1)
                    {
                        Damage *= 2;
                    }

                    PBullet.SetType(Version, bulletCnt, Damage);
                }
                if (gameObject.name == "Dark")
                {
                    _audio.Play();
                }

            }

        }
    }
}

