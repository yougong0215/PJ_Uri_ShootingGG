using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet_Pull : MonoBehaviour
{
    private Vector3 dir = Vector3.up;
    [SerializeField]float speed = 10;
    GameObject Target;
    Vector3 Enemy;

    // Update is called once per frame
    void FixedUpdate()
    {
        speed = 15f;
        if(Input.GetKey(KeyCode.LeftShift))
        {
            try
            {
                Target = GameObject.FindWithTag("Enemy");
                Enemy = Target.GetComponent<Transform>().transform.position;
                dir = Enemy - transform.position;
                dir.Normalize();
            }catch
            {
                dir = Vector3.zero;
                dir = Vector3.up;
            } 
        }
        else
        {
            dir = Vector3.zero;
            dir = Vector3.up;
        }
        transform.position += speed * dir * Time.deltaTime;

        FalseBullet();

    }
    void FalseBullet()
    {
        if (Mathf.Abs(transform.position.y) >= 5)
        {
            
            gameObject.SetActive(false);
            transform.SetParent(GameManager.InstancePro.PoolManagerpro.transform);
        }
    }

}
