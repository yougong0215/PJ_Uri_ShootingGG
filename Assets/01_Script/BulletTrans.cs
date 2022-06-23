using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class BulletTrans : MonoBehaviour
{
    // 1 : 30

    protected Vector3 dir;
    float currentTIme;
    int ItemRandom;
    PowerItem item;
    public abstract void Reset();
    [SerializeField]
    protected float HP;

    public void Awake()
    {
        //_ShootNormalMonster = GameManager.Instance.AudioReturn(1);
        currentTIme = 0;
        dir = Vector3.down;
    }
    public void SetHp(float value)
    {
        HP = value;
    }
    public void Update()
    {
        if (transform.parent.GetComponent<Stage1Patton>() == false)
        {
            transform.position += 3 * dir * Time.deltaTime;
        }

    }

    public virtual void SetDir(Vector3 value)
    {
        dir += value;
    }
    public void StaticSetDir(Vector3 value)
    {
        dir = value;
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            HP -= collision.GetComponent<PlayerBullet>().GetDamage();
            //PoolManager.Instance.Push(collision.GetComponent<PlayerBullet>());
        }
    }
    public void GetDamage(float value)
    {
        HP -= value;
        //Debug.Log($"{gameObject}, {HP}");
    }
    public void CreateItem()
    {
        ItemRandom = UnityEngine.Random.Range(0, 101);
        if (ItemRandom > 20 && ItemRandom < 70)
        {
            item = PoolManager.Instance.Pop("Power_Item") as PowerItem;
            item.SetPos(gameObject.transform.position);
        }
        else if (ItemRandom > 1 && ItemRandom <= 20)
        {
            item = PoolManager.Instance.Pop("Big_Power_Item") as PowerItem;
            item.SetPos(gameObject.transform.position);
        }
        else if(ItemRandom <= 1)
        {

        }

    }
}
