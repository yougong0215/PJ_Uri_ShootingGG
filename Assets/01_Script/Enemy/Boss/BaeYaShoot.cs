using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaeYaShoot : BulletTrans
{
    Transform Target;
    Vector3 dir = Vector3.down;
    Vector3 TargetT;
    float speed;
    int Patton;
    public override void Reset()
    {
        speed = 0;
        dir = Vector3.down;
    }
    private void OnEnable()
    {
        HP = 10000;
        Alpahs = false;
    }
    private void Awake()
    {

    }
    bool Alpahs = false;

    public void SetDir(Vector3 value, float speed, int Patton)
    {

        this.speed = speed;
        this.Patton = Patton;
        switch (Patton)
        {
            case 1:
                StartCoroutine(SpeedDown());
                dir = value;
                dir.Normalize();
                break;
            case 2:
                StartCoroutine(MoveDir(value));
                break;
            case 3:
                StartCoroutine(RotMove(value));
                break;
            case 4:
                dir = Vector3.zero;
                StartCoroutine(Patton4(value));
                break;
            case 5:
                StartCoroutine(patton5(value));
                break;
            case 6:
                StartCoroutine(AlphaBee());
                break;
        }
    }
    IEnumerator AlphaBee()
    {
        transform.position = new Vector3(Random.Range(9.5f, 16.5f), Random.Range(10f, 20f));
        Alpahs = true;
        TargetT = new Vector3(transform.position.x - 10, transform.position.y - 10);
        dir = TargetT - transform.position;
        dir.Normalize();
        speed = 0;
        yield return new WaitForSeconds(1f);
        speed = Random.Range(3, 8);

    }
    IEnumerator patton5(Vector3 vector3)
    {
        yield return new WaitForSeconds(0.5f);

        if (speed % 2 == 0)
        {
            dir = Vector3.left;
        }
        else
            dir = Vector3.right;
        speed = 0;
        yield return new WaitForSeconds(0.5f);
        speed = Random.Range(4, 10);
    }

    float currentTime;
    // Update is called once per frame
    void Update()
    {
        HP = 10000;
        transform.position += dir * speed * Time.deltaTime;
    }

    IEnumerator Patton4(Vector3 value)
    {
        yield return new WaitForSeconds(1.5f);
        dir = value;
    }
    IEnumerator MoveDir(Vector3 value)
    {
        dir = Vector3.down;
        yield return new WaitForSeconds(UnityEngine.Random.RandomRange(1f, 3f));
        speed = 1f;
        dir = value;
        yield return new WaitForSeconds(1f);
        speed = 10f;
    }
    IEnumerator SpeedDown()
    {
        yield return new WaitForSeconds(1.5f);
        speed = 5f;
    }
    IEnumerator RotMove(Vector3 value)
    {
        speed = 6f;
        yield return new WaitForSeconds(0.5f);
        speed = 4;
        dir = value;
        yield return new WaitForSeconds(2f);
        for (int i = 1; i < 36; i++)
        {
            dir = (Quaternion.Euler(0, 0, 10 * i) * Vector3.right);
            dir.Normalize();
            yield return new WaitForSeconds(0.1f);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Slash>())
        {
            PoolManager.Instance.Push(this);
        }
        else if (collision.GetComponent<PlayerSwing>())
        {
            PoolManager.Instance.Push(this);
        }
    }
    private void LateUpdate()
    {
        currentTime += Time.deltaTime;
        if(currentTime> 5f)
        {
            currentTime = 0;
            PoolManager.Instance.Push(this);
        }
    }
    public void CreateItem()
    {
        // ÇÏÀÌµù
    }

}
