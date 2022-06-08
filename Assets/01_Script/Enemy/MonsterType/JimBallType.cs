using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JimBallType : BulletTrans
{
    BlueBullet BB;
    int BoundCheck;

    public override void Reset()
    {
        BoundCheck = 0;
    }
    public void OnEnable()
    {
        StartCoroutine(Type1());
    }

    IEnumerator Type1()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    BB = PoolManager.Instance.Pop("BlueBullet") as BlueBullet;
                    BB.SetDir(i, 4, 2, gameObject);
                    BB.transform.position = transform.position;
                    
                }
                yield return new WaitForSeconds(0.1f);
            }
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(BoundCheck >= 2)
        {
            PoolManager.Instance.Push(this);
        }

        dir = Vector3.Reflect(dir, ((Vector2)transform.position - collision.contacts[0].point).normalized);
        BoundCheck++;
        
    }
}
