using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JimBallType : BulletTrans
{
    BlueBullet BB;
    

    public override void Reset()
    {
        HP = 30;
    }
    public void OnEnable()
    {
        HP = 30;
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
}
