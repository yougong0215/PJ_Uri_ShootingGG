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
    float currentTime;
    private void OnEnable()
    {
        currentTime = 0;
        speed = 10;
        shift = false;
        StartCoroutine(BulletDieTime());
        HP = 10000;
    }
    public void SetType(int Version, int i, float Damage)
    {
        Typeint = Version;
        number = i;
        bulletDamage = Damage;
        currentTime = 0;
        shift = false;
    }
    public float GetDamage()
    {
        if(shift == true)
        {
            bulletDamage += 1;
        }

        return bulletDamage;
    }

    // Update is called once per frame
    void Update()
    {
        speed = 15f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            shift = true;
        }
        Type();
        
        transform.position += speed * dir * Time.deltaTime;

        FalseBullet();
        currentTime += Time.deltaTime;

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
        if (currentTime <= 0.1f || shift == false)
        {
            switch (Typeint)
            {
                case 1:
                    dir = Vector3.up;
                    break;

                case 2:
                    switch (number)
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

        if (shift == true)
        {
            Invoke("DIRUP", 0.2f);
        }
    }
    void DIRUP()
    {
        dir = Vector3.up;
    }

    public override void Reset()
    {
    }
    IEnumerator BulletDieTime()
    {
        yield return new WaitForSeconds(1f);
        PoolManager.Instance.Push(this);
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent("Enemy"))
        {
            PoolManager.Instance.Push(this);
        }
    }
}
