using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
     private float speed = 5;
    [SerializeField] PlayerSwing _pswing;
    float h = 0f;
    float v = 0f;
    const string Patten1 = "StagePattern1";
    Vector3 dir;
    SceneData _SC;

    private void Awake()
    {
        _SC = GameObject.Find("StartData").GetComponent<SceneData>();
        // Á×À½ ¹ÞÀ» ¿¹Á¤
    }
    
    



    void Update()
    {
        if (_pswing.GetNova() == true)
        {
            speed = 8;
        }
        else
            speed = 5;
        if(_SC.GetDiff() == 1 || _SC.GetDiff() == 2)
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");
        }
        else
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
        }


        dir = new Vector3(h, v, 0);
        if (Input.GetKey(KeyCode.LeftShift))
        {

            transform.position += dir * speed * Time.deltaTime /4;
        }
        else
        {
            transform.position += dir * speed * Time.deltaTime;
        }

        transform.position =
        new Vector3(Mathf.Clamp(transform.position.x, -6.5f, 1.5f),
        Mathf.Clamp(transform.position.y, -5f, 5f), 0);

        // ±êÇãºê ³¯¸Ô¿ë ¼öÁ¤
    }
}
