using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LightAndDarkExplosion : MonoBehaviour
{
    float currentTime;
    PlayerSwing _pSwing;
    float CheckTime = 2.5f;
    void Start()
    {
        _pSwing = GameObject.Find("Player/Sprite").GetComponent<PlayerSwing>();
    }
    private void OnEnable()
    {
        currentTime = 0;
        if (gameObject.name == "LightEx")
        {
            transform.localScale = new Vector3(0f, 0f, 0f);
            transform.DOScale(new Vector3(5f,5f,1f), 2).OnComplete(() => { gameObject.SetActive(false); });
        }
        if (gameObject.name == "DarkEx")
        {
            transform.localScale = new Vector3(30f, 30f, 100f);
            transform.DOScale(new Vector3(0f, 0f, 1f), 2).OnComplete(() => { gameObject.SetActive(false); });
        }
    }
    private void Update()
    {
        if(_pSwing.GetNova() == true)
        {
            CheckTime = 5f;
        }    
        else
        {
            CheckTime = 2.5f;
        }
        if (currentTime > CheckTime)
        {
            if (gameObject.name == "LightEx" && gameObject.transform.localScale != new Vector3(5, 5, 1))
            {
                gameObject.SetActive(false);
            }
            if (gameObject.name == "DarkEx" && gameObject.transform.localScale != new Vector3(0, 0, 1))
            {
                gameObject.SetActive(false);
            }
        }
        currentTime += Time.deltaTime;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.name == "DarkEx" && collision.GetComponent<BulletTrans>())
        {
            
            collision.GetComponent<BulletTrans>().GetDamage(100);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.name == "LightEx")
        {
            if(collision.GetComponent<BlueBullet>() || collision.GetComponent<BaeYaShoot>())
                collision.gameObject.SetActive(false);
        }
    }

}
