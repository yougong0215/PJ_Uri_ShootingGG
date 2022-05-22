using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBullet : BulletTrans
{
    float currenttime;
    float speed = 0;
    int a = 1;
    int Version = 0;

    Vector3 ObjectPos;

    Vector3 dir = Vector3.down;
    public Vector3 GetDir()
    {
        return dir;
    }

    Vector2 DownLeft = Vector2.down + Vector2.left;   // 0
    Vector2 Middle = Vector2.down;                    // 1
    Vector2 DownRight = Vector2.down + Vector2.right; // 2
    Vector2 Right = Vector2.right;                    // 3
    Vector2 RightUp = Vector2.right + Vector2.up;     // 4
    Vector2 Up = Vector2.up;                          // 5
    Vector2 LeftUp = Vector2.left + Vector2.up;       // 6
    Vector2 Left = Vector2.left;                      // 7

    public void SetDir(int value, int speed, int Version, GameObject obj)
    {
        a = value;
        this.speed = speed;
        this.Version = Version;
        dir = Vector2.zero;
        ObjectPos = obj.transform.position;
        switch (Version)
        {
            case 0:
                Version0(); // CrazyBird
                break;
            case 1:
                Version1();// CrazyBird
                break;
            case 2:
                Version2(); // Jimball
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 3방향 발사 아렛쪽( 왼쪽, 오른쪽, 아레 )
    /// </summary>
    void Version0()
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

    void Version1()
    {
        GameObject Player = GameObject.Find("Player");
        dir = Player.transform.position - ObjectPos;
        dir.Normalize();
        Debug.Log(dir);
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
        if (gameObject.activeSelf)
        {
            currenttime += Time.deltaTime;
        }

        if (Mathf.Abs(transform.position.y) >= 7)
        {
         //   GameManager.InstancePro.BlueDespawn(gameObject);
        }

    }

    void Version5()
    {

    }

    int i = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {



        if (Version == 1)
        {
            dir = Vector3.Reflect(dir, ((Vector2)transform.position - collision.contacts[0].point).normalized);
            speed = 5;
            i++;
            if (i == 2)
            {
                i = 0;

           //     GameManager.InstancePro.BlueDespawn(gameObject);
            }
        }
        else
        {

         //   GameManager.InstancePro.BlueDespawn(gameObject);
        }
    }

    public override void Reset()
    {
    }


    // 예네는 게임 오브잭트 안에 만들어주는게 훨편함 ㅇㅇ
    /*
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
    
    */

}
