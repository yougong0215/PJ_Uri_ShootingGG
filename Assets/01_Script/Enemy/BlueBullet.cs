using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBullet : MonoBehaviour
{
    float speed = 2;
    int a;
    Vector3 dir = Vector3.down;
    Vector2 Left = new Vector2(-1, -2);
    Vector2 Middle = new Vector2(0, -2);
    Vector2 Right = new Vector2(1, -2);
    public void SetDir(int value)
    {
        a = value;
    }

    void FixedUpdate()
    {
        switch(a)
        {
            case 0:
                dir = Left;
                break;
            case 1:
                dir = Middle;
                break;
            case 2:
                dir = Right;
                break;
        }

        transform.position += speed * dir * Time.deltaTime;
        if (transform.position.y <= -4)
        {
            gameObject.SetActive(false);
            transform.SetParent(GameManager.InstancePro.bluePoolManagerpro.transform);
        }

    }

}
