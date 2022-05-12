using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBullet : MonoBehaviour
{
    float currenttime;
    float speed = 0;
    int a = 1;
    int Version = 0;
    Vector3 dir = Vector3.down;
    public void SetDir(Vector3 dir)
    {
        this.dir = dir;
        Debug.Log($"dir : {this.dir} | ThatDir {dir}");
    }
    public Vector3 GetDir()
    {
        Debug.Log("daf2");
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

    private void Start()
    {
        
        switch(Version)
        {
            case 0:
                Version0();
                break;
            case 1:
                Version1();
                break;
            case 2:
                Version2();
                break;
            default:
                break;
        }

        dir.Normalize();
        Debug.Log($"ThatDir {dir}");

    }
    public void SetDir(int value, int speed, int Version)
    {
        a = value;
        this.speed = speed;
        this.Version = Version;
        Start();
    }
    /// <summary>
    /// 3���� �߻� �Ʒ���( ����, ������, �Ʒ� )
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
        dir = Player.transform.position - transform.position;
        dir.Normalize();
    }

    /// <summary>
    /// 8���� �߻�
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
        if(gameObject.activeSelf)
        {
            currenttime += Time.deltaTime;
        }

        if (Mathf.Abs(transform.position.y) >= 7 || currenttime > 4)
        {
            gameObject.SetActive(false);
            transform.SetParent(GameManager.InstancePro.bluePoolManagerpro.transform);
            currenttime = 0;
        }

    }

    void Version5()
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        dir = Vector3.Reflect(dir, ((Vector2)transform.position - collision.contacts[0].point).normalized);
    }


    // ���״� ���� ������Ʈ �ȿ� ������ִ°� ������ ����
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
