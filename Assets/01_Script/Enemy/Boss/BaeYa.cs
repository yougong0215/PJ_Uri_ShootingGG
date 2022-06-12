using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class BaeYa : BulletTrans
{
    [SerializeField] Image WhiteHP;
    [SerializeField] Image RedHP;
    [SerializeField] Transform Player;
    Image thisHP;
    float OriginHP;
    Vector3 direction = Vector3.right;
    Vector3 newDirection;
    BaeYaShoot bullet;
    float Rot;
    float Rot2;
    float speed;
    float currentTime;
    IEnumerator cor;

    #region
    bool FirstPatton = false;
    bool SecondPatton = false;
    #endregion
    // Start is called before the first frame 
    void OnEnable()
    {
        thisHP = WhiteHP;
        HP = 1000;
        OriginHP = HP;
        Rot = 0;
        SecondPatton = true;
    }
    private void Start()
    {
        HP = 1000;
    }
    private void Awake()
    {
        
    }
    private void LateUpdate()
    {
        if (thisHP == WhiteHP && (HP / OriginHP) * 10 <= 1)
        {
            FirstPatton = true;
            SecondPatton = true;
                        StopAllCoroutines();
            thisHP.fillAmount = 0;
            thisHP = RedHP;
            HP = 500;

            FirstPatton = false;
        }
        thisHP.fillAmount = (HP / OriginHP);
        if (thisHP == RedHP && HP <=0)
        {
            PoolManager.Instance.Push(this);
        }


    }
    private void Update()
    {
        currentTime += Time.deltaTime;

        if (thisHP == WhiteHP)
        {
            if (FirstPatton == false)
            {
                //Rot = 0;
                FirstPatton = true;
                transform.DOMove(new Vector3(-3, 3, 0), 1f).OnComplete(() =>
                {
                     StartCoroutine(BossBullet1()); 
                    StartCoroutine(BossBullet2());

                });
            }
            if (SecondPatton == false)
            {
                //Rot = 0;
                SecondPatton = true;
                transform.DOMove(new Vector3(-5, 3, 0), 1f).OnComplete(() =>
                {
                    StartCoroutine(Patton2());
                    transform.DOMove(new Vector3(-1, 3, 0), 3f);
                });
            }
        }
        else if (thisHP == RedHP)
        {
            if (FirstPatton == false)
            {
                Rot = 0;
                FirstPatton = true;
                transform.DOMove(new Vector3(0, 4, 0), 1f).OnComplete(() =>
                {
                    StartCoroutine(Patton3());
                    transform.DOMove(new Vector3(-6, 4, 0), 4).SetEase(Ease.Linear);
                });
            }
            if(SecondPatton == false)
            {
                SecondPatton = true;
                transform.DOMove(new Vector3(-3, 3, 0), 1f).OnComplete(() =>
                {
                    StartCoroutine(Patton4());
                });
            }
        } 
        
    }
    #region ���� 1
    IEnumerator BossBullet1()
    {
        for (int j = 1; j <= 30; j++)
        {
            for (int i = 1; i <= 5; i++)
            {

                bullet = PoolManager.Instance.Pop("FireBullet_") as BaeYaShoot;
                bullet.transform.position = transform.position;
                bullet.SetDir(Quaternion.Euler(0, 0, 345 - 30 * i + Rot) * direction, 0.4f, 1);
                bullet.SetHp(150);
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForSeconds(0.15f);
            if (j < 5)
            {
                Rot -= 1.5f;
            }
            else
            {
                Rot += 1.5f;
            }
        }
        SecondPatton = false;
    }
    IEnumerator BossBullet2()
    {
        for (int j = 1; j <= 30; j++)
        {
            for (int i = 1; i <= 5; i++)
            {
                bullet = PoolManager.Instance.Pop("FireBullet_") as BaeYaShoot;
                bullet.transform.position = transform.position;
                bullet.SetDir(Quaternion.Euler(0, 0, 195 + 30 * i + Rot2) * Vector3.right, 0.4f, 1);
                bullet.SetHp(150);
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForSeconds(0.15f);
            if (j < 5)
            {
                Rot2 += 1.5f;
            }
            else
            {
                Rot2 -= 1.5f;
            }
        }
    }
    #endregion
    IEnumerator Patton2()
    {
        for (int j = 1; j <= 15; j++)
        {
            for (int i = 1; i <= 3; i++)
            {
                bullet = PoolManager.Instance.Pop("FireBullet_") as BaeYaShoot;
                bullet.transform.position = transform.position;
                bullet.SetDir(Quaternion.Euler(0, 0, 30 * UnityEngine.Random.Range(0,12)) * Vector3.right, 3f, 2);
                bullet.SetHp(150);
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForSeconds(0.2f);
        }
    
        yield return new WaitForSeconds(0.5f);
        transform.DOMove(new Vector3(-1, 3, 0), 1f).OnComplete(() =>
        {
            StartCoroutine(Patton2_To());
            transform.DOMove(new Vector3(-5, 3, 0), 3f).OnComplete(()=>
            {
                FirstPatton = false;
            });
        });
    }
    IEnumerator Patton2_To()
    {
        for (int j = 1; j <= 15; j++)
        {
            for (int i = 1; i <= 3; i++)
            {
                bullet = PoolManager.Instance.Pop("FireBullet_") as BaeYaShoot;
                bullet.transform.position = transform.position;
                bullet.SetDir(Quaternion.Euler(0, 0, 30 * UnityEngine.Random.Range(0, 12)) * Vector3.right, 3f, 2);
                bullet.SetHp(150);
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForSeconds(0.2f);
        }
     
    }
        IEnumerator Patton3()
    {
        for (int j = 1; j <= 15; j++)
        {
            for (int i = 1; i <= 12; i++)
            {
                bullet = PoolManager.Instance.Pop("FireBullet_") as BaeYaShoot;
                bullet.transform.position = transform.position;
                bullet.SetDir(Quaternion.Euler(0, 0, 30 * i) * Vector3.right, 0.5f, 3);
                bullet.SetHp(150);
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.5f);
        transform.DOMove(new Vector3(-3, 3, 0), 1f).OnComplete(() =>
        {
            StartCoroutine(Patton3End());
        });
    }
    IEnumerator Patton3End()
    {
        for (int j = 1; j <= 15; j++)
        {
            for (int i = 1; i <= 12; i++)
            {
                bullet = PoolManager.Instance.Pop("FireBullet_") as BaeYaShoot;
                bullet.transform.position = transform.position;
                bullet.SetDir(Quaternion.Euler(0, 0, 30 * i) * Vector3.right, 4f, 1);
                bullet.SetHp(150);
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1.5f);
        SecondPatton = false ;
    }
    IEnumerator Patton4()
    {
        for (int j = 1; j <= 15; j++)
        {
            for (int i = 1; i <= 3; i++)
            {

                bullet = PoolManager.Instance.Pop("FireBullet_") as BaeYaShoot;
                while (true)
                {

                    bullet.transform.position = Player.transform.position + new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
                    if (Mathf.Abs(bullet.transform.position.x - Player.position.x) < 1f && bullet.transform.position.y - Player.position.y < Mathf.Abs(0.3f))
                    {
                        bullet.transform.position = Player.transform.position + new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
                    }
                    else
                        break;
                }
                    bullet.SetDir(Player.position - bullet.transform.position, 3f, 4);
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForSeconds(0.3f);
        }
        FirstPatton = false;
    }

    public override void Reset()
    {
        throw new System.NotImplementedException();
    }
}