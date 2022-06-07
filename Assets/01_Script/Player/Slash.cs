using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : BulletTrans
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * Vector3.up * 8;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<BulletTrans>().GetDamage(50);
        if(collision.name == "BlueBullet")
        {
            PoolManager.Instance.Push(collision.gameObject.GetComponent<BulletTrans>());
        }    
    }

    public override void Reset()
    {
    }
}
