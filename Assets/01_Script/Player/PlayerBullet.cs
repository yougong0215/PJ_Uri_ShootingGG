using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : BulletTrans
{
    private Vector3 dir = Vector3.up;
    [SerializeField] float speed = 10;
    bool shift;
    float bulletDamage;
    private int Typeint;
    private int number;
    float currentTime;
    private void OnEnable()
    {
    }
    public void SetType(int Version, int i, float Damage)
    {
        Typeint = Version;
        number = i;
        bulletDamage = Damage;
        speed = 10;
        currentTime = 0;
        shift = false;
        HP = 10000;
        UPcheck = false;
    }
    public float GetDamage()
    {
        if(shift == true)
        {
            bulletDamage -= 0.5f;
        }

        return bulletDamage;
    }

    // Update is called once per frame
    void Update()
    {
        HP = 10000;
        speed = 15f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            shift = true;
        }
        Type();
        
        transform.position += speed * dir * Time.deltaTime;
        currentTime += Time.deltaTime;

    }
    private void LateUpdate()
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
                            dir = new Vector3(0.1f, 0.9f, 0);
                            break;
                        case 2:
                            dir = new Vector3(-0.1f, 0.9f, 0);
                            break;
                    }
                    break;

                case 3:
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
                case 4:
                    switch (number)
                    {
                        case 1:
                            dir = new Vector3(0.1f, 0.8f, 0);
                            break;
                        case 2:
                            dir = new Vector3(0, 1, 0);
                            break;
                        case 3:
                            dir = new Vector3(-0.1f, 0.8f, 0);
                            break;
                        case 4:
                            dir = new Vector3(-0.05f, 0.8f, 0);
                            break;
                        case 5:
                            dir = new Vector3(0.05f, 0.8f, 0);
                            break;
                    }
                    break;
                case 5:
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

        if (currentTime >= 0.1f && shift == true && UPcheck == false)
        {
            UPcheck = true;
            dir = Vector3.up;
        }
    }

    bool UPcheck = false;

    public override void Reset()
    {
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            PoolManager.Instance.Push(this);
        }
    }
}
