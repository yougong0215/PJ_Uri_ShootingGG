using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBullet : MonoBehaviour
{
    float speed = 5;
    int a;
    Vector3 dir = Vector3.down;
    Vector2 Left = new Vector2(-1, -1);
    Vector2 Middle = new Vector2(0, -1);
    Vector2 Right = new Vector2(1, -1);
    public void SetDir(Vector3 value)
    {
        dir = value;
        a = BlueBulletManager.blueDir;
    }
    public Vector3 GetDir()
    {
        return dir;
    }
    void FixedUpdate()
    {
        switch(a)
        {
            case 1:
                dir = Left;
                break;
            case 2:
                dir = Middle;
                break;
            case 3:
                dir = Left;
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
