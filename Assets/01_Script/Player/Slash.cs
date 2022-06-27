using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : BulletTrans
{
    PlayerItem Pitem;
    int SlashDie;
    int a;
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
    public void SetDirH(int i)
    {
        transform.Rotate(0, 0, 0);
        a = i;
        switch(i)
        {
            case 1:
                dir = new Vector3(0, 1, 0);
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                break;
            case 2:
                dir = new Vector3(0.5f, 0.8f, 0);
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, -45));
                break;
            case 3:
                dir = new Vector3(-0.5f, 0.8f, 0);
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 45));
                break;
        }
        dir.Normalize();
    }

    void Update()
    {
        transform.position += Time.deltaTime * dir * 8;
        if (gameObject.name == "WindSlash"&& SlashDie >= 10 + Pitem.GetPowerCnt()/5)
        {
            PoolManager.Instance.Push(this);
        }
        if (gameObject.name == "MiniSlash" && SlashDie >= 1)
        {
            PoolManager.Instance.Push(this);
        }
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        SlashDie++;
        if (gameObject.name == "WindSlash")
        {
            collision.gameObject.GetComponent<BulletTrans>().GetDamage(50 + Pitem.GetPowerCnt());
        }
        if (gameObject.name == "MiniSlash")
        {
            collision.gameObject.GetComponent<BulletTrans>().GetDamage(5 + Pitem.GetPowerCnt()/5);
        }
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
