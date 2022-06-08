using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    BulletTransP CBT;
    JimBallType JBT;
    float h = 0f;
    float v = 0f;
    const string Patten1 = "StagePattern1";
    Vector3 dir;
    private void Awake()
    {
        // ���� ���� ����
    }
    
    



    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        dir = new Vector3(h, v, 0);
        if (Input.GetKey(KeyCode.LeftShift))
        {

            transform.position += dir * speed * Time.deltaTime /4;
        }
        else
        {
            transform.position += dir * speed * Time.deltaTime;
        }

        transform.position = new Vector3 (Mathf.Clamp(transform.position.x, -6.5f, 0f), Mathf.Clamp(transform.position.y, -5f, 5f), 0);
        // ����� ���Կ� ����
    }
}
