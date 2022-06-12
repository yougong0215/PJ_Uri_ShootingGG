using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LightAndDarkExplosion : MonoBehaviour
{
    void Start()
    {
    }
    private void OnEnable()
    {
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
            if(collision.GetComponent<BlueBullet>())
                collision.gameObject.SetActive(false);
        }
    }

}
