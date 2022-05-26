using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : BulletTrans
{
    private Vector3 dir = Vector3.up;
    [SerializeField] float speed = 10;
    GameObject Target;
    Vector3 Enemy;
    bool shift;
    float bulletDamage;
    private int Typeint;
    private int number;
    public void SetType(int Version, int i, float Damage)
    {
        Typeint = Version;
        number = i;
        bulletDamage = Damage;
    }
    public float GetDamage()
    {
        if(shift == true)
        {
            bulletDamage /= 2;
        }

        return bulletDamage;
    }

    // Update is called once per frame
    void Update()
    {
        speed = 15f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            try
            {
                shift = true;
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
                        dir = new Vector3(0.2f, 0.8f, 0);
                        break;
                    case 2:
                        dir = new Vector3(0, 1, 0);
                        break;
                    case 3:
                        dir = new Vector3(-0.2f, 0.8f, 0);
                        break;
                }
                break;
            case 3:
                switch (number)
                {
                    case 1:
                        dir = new Vector3(0.1f, 0.8f, 0);
                        break;
                    case 2:
                        dir = new Vector3(0.2f, 0.6f, 0);
                        break;
                    case 3:
                        dir = new Vector3(0, 1, 0);
                        break;
                    case 4:
                        dir = new Vector3(-0.2f, 0.6f, 0);
                        break;
                    case 5:
                        dir = new Vector3(-0.1f, 0.8f, 0);
                        break;
                }
                break;
        }
    }


    public override void Reset()
    {
        speed = 10;
        shift = false;
        StartCoroutine(BulletDieTime());
    }
    IEnumerator BulletDieTime()
    {
        yield return new WaitForSeconds(1f);
        PoolManager.Instance.Push(this);
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent("Enemy"))
        {
            PoolManager.Instance.Push(this);
        }
    }
}
