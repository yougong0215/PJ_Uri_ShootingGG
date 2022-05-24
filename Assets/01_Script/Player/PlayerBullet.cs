using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : BulletTrans
{
    private Vector3 dir = Vector3.up;
    [SerializeField] float speed = 10;
    GameObject Target;
    Vector3 Enemy;

    private int Typeint;
    private int number;
    public void SetType(int Version, int i)
    {
        Typeint = Version;
        number = i;
    }


    // Update is called once per frame
    void Update()
    {
        speed = 15f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            try
            {
                Target = GameObject.FindWithTag("Enemy");
                Enemy = Target.GetComponent<Transform>().transform.position;
                dir = Enemy - transform.position;
                dir.Normalize();
            }
            catch
            {
                Type();
            }
        }
        else
        {
            Type();
        }
        transform.position += speed * dir * Time.deltaTime;

        FalseBullet();

    }
    void FalseBullet()
    {
        if (Mathf.Abs(transform.position.y) >= 7)
        {

            PoolManager.Instance.Push(this);
        }
    }

    void Type()
    {
        switch(Typeint)
        {
            case 1:
                dir = Vector3.up;
                break;

            case 2:
                switch(number)
                {
                    case 1:
                        dir = new Vector3(0.2f, 1, 0);
                        break;
                    case 2:
                        dir = new Vector3(0, 1, 0);
                        break;
                    case 3:
                        dir = new Vector3(-0.2f, 1, 0);
                        break;
                }
                break;
        }
    }


    public override void Reset()
    {
        speed = 10;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PoolManager.Instance.Push(this);
    }
}
