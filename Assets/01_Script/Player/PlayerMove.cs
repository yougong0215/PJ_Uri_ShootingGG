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
        // Á×À½ ¹ÞÀ» ¿¹Á¤
    }
    
    



    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        dir = new Vector3(h, v, 0);
        if (Input.GetKey(KeyCode.LeftShift))
        {

            transform.position += dir * speed * Time.deltaTime /4;
        }
        else
        {
            transform.position += dir * speed * Time.deltaTime;
        }

        transform.position = new Vector3 (Mathf.Clamp(transform.position.x, -7f, -0.5f), Mathf.Clamp(transform.position.y, -5f, 5f), 0);
        // ±êÇãºê ³¯¸Ô¿ë ¼öÁ¤
    }
}
