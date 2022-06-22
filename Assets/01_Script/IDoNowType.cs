using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDoNowType : BulletTrans
{
    BlueBullet BB;
    float currentTime;
    Vector3 dir;
    Transform player;
    public override void Reset()
    {
    }
    public void OnEnable()
    {
        currentTime = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.PlayerPos();
    }

    private void Update()
    {
        if (currentTime < 3f)
        {
            dir = player.position - transform.position;
            dir.Normalize();
        }
        transform.position = dir * Time.deltaTime * 2f;

    }

    public void LateUpdate()
    {
        currentTime += Time.deltaTime;
        if (transform.parent == null)
        {
            if (currentTime >= 8f)
            {
                PoolManager.Instance.Push(this);
            }

            if (Mathf.Abs(transform.position.y) >= 15f)
            {
                PoolManager.Instance.Push(this);
            }
        }
        if (HP <= 0)
        {
            CreateItem();
            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j< 8; j++)
                {
                    BB = PoolManager.Instance.Pop("BlueBullet") as BlueBullet;
                    BB.SetDir(j, 0, 3, gameObject);
                }
            }
            PoolManager.Instance.Push(this);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            PoolManager.Instance.Push(this);
        }
    }

}
