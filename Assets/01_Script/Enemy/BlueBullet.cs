using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBullet : MonoBehaviour
{
    float speed = 0;
    int a = 1;
    int Version = 0;
    Vector3 dir = Vector3.down;
    
    Vector2 DownLeft = Vector2.down + Vector2.left;   // 0
    Vector2 Middle = Vector2.down;                    // 1
    Vector2 DownRight = Vector2.down + Vector2.right; // 2
    Vector2 Right = Vector2.right;                    // 3
    Vector2 RightUp = Vector2.right + Vector2.up;     // 4
    Vector2 Up = Vector2.up;                          // 5
    Vector2 LeftUp = Vector2.left + Vector2.up;       // 6
    Vector2 Left = Vector2.left;                      // 7

    private void Start()
    {
        StartCoroutine("DiamondTurn");
    }
    public void SetDir(int value, int speed, int Version)
    {
        a = value;
        this.speed = speed;
        this.Version = Version;
    }
    /// <summary>
    /// 3방향 발사 아렛쪽( 왼쪽, 오른쪽, 아레 )
    /// </summary>
    void Version1()
    {
        switch (a)
        {
            case 0:
                dir = DownLeft;
                break;
            case 1:
                dir = Middle;
                break;
            case 2:
                dir = DownRight;
                break;
        }
    }

    /// <summary>
    /// 8방향 발사
    /// </summary>
    void Version2()
    {
        switch (a)
        {
            case 0:
                dir = DownLeft;
                break;
            case 1:
                dir = Middle;
                break;
            case 2:
                dir = DownRight;
                break;
            case 3:
                dir = Right;
                break;
            case 4:
                dir = RightUp;
                break;
            case 5:
                dir = Up;
                break;
            case 6:
                dir = LeftUp;
                break;
            case 7:
                dir = Left;
                break;
        }
    }

    void FixedUpdate()
    {
        transform.position += speed * dir * Time.deltaTime;
        if (transform.position.y <= -4)
        {
            gameObject.SetActive(false);
            transform.SetParent(GameManager.InstancePro.bluePoolManagerpro.transform);
        }

    }

    IEnumerator BoxTurn()
    {
        dir = new Vector3(0, -2, 0);
        yield return new WaitForSeconds(0.5f);
        dir = new Vector3(-1, 0, 0);
        yield return new WaitForSeconds(0.5f);
        dir = new Vector3(0, 1, 0);
        yield return new WaitForSeconds(0.5f);
        dir = new Vector3(1, 0, 0);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("BoxTurn");
    }

    IEnumerator DiamondTurn()
    {
        dir = new Vector3(1, -1, 0);
        yield return new WaitForSeconds(0.5f);
        dir = new Vector3(-1, -1, 0);
        yield return new WaitForSeconds(0.5f);
        dir = new Vector3(-1, 1, 0);
        yield return new WaitForSeconds(0.5f);
        dir = new Vector3(1, 1, 0);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("DiamondTurn");
    }
    

   // IEnumerator DiamondTurn()
    //{

    
}
