using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : BulletTrans
{
    PlayerItem Pitem;
    int SlashDie;
    private void Awake()
    {
        Pitem = GameObject.Find("Player").GetComponent<PlayerItem>();
    }

    // Start is called before the first frame update
    private void OnEnable()
    {
        HP = 10000;
        SlashDie = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * Vector3.up * 8;
        if (SlashDie >= 10 + Pitem.GetPowerCnt()/5)
        {
            PoolManager.Instance.Push(this);
        }
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        SlashDie++;
        collision.gameObject.GetComponent<BulletTrans>().GetDamage(50 + Pitem.GetPowerCnt());
        if (collision.name == "BlueBullet")
        {
            PoolManager.Instance.Push(collision.gameObject.GetComponent<BulletTrans>());
        }
    }

    public override void Reset()
    {
        HP = 10000;
    }
}
