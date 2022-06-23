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
    public void SetDirH(int i)
    {
        transform.Rotate(0, 0, 0);

        switch(i)
        {
            case 1:
                dir = new Vector3(0, 1, 0);
                break;
            case 2:
                dir = new Vector3(0.5f, 0.8f, 0);
                transform.Rotate(0, 0, -45);
                break;
            case 3:
                dir = new Vector3(-0.5f, 0.8f, 0);
                transform.Rotate(0, 0, 45);
                break;
        }
        dir.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * dir * 8;
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
