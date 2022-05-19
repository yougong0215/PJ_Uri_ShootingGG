using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BlueBulletManager : MonoBehaviour
{

    int RandomValue;
    public GameObject Bullet;
    private Transform poolManagertransform = null;
    [SerializeField] private BlueBullet BDir;
    [SerializeField] private GameObject SpriteName;
    void Start()
    {
        poolManagertransform = FindObjectOfType<BluePullManager>().GetComponent<Transform>();
        StartCoroutine("EnableBullet");
    }

    bool JimballBoom =false;
    bool BirdCheck = false;
    IEnumerator EnableBullet()
    {
        while (true)
        {
            GameObject obj = null;
            if (SpriteName.name == "CrazyBirdSprite" && BirdCheck == false)
            {
                RandomValue = UnityEngine.Random.Range(0, 2); // 일단 랜덤 박음
                BirdCheck = true;

                    for (int j = 0; j < 3; j++)
                    {
                        if (poolManagertransform.childCount > 0)
                        {
                            obj = poolManagertransform.GetChild(0).gameObject;
                            obj.SetActive(true);
                        }
                        else
                        {
                            obj = Instantiate(Bullet, transform);
                        }
                        obj.transform.SetParent(null);
                        BDir = obj.gameObject.GetComponent<BlueBullet>();
                        BDir.SetDir(j, 10, RandomValue, gameObject);
                        obj.transform.position = transform.position;
                        if(RandomValue == 1)
                             yield return new WaitForSeconds(0.1f);
                    }
                BirdCheck = false;
            }


            else if (SpriteName.name == "JimballSprite" && JimballBoom == false)
            {
                JimballBoom = true;
                yield return new WaitForSeconds(4f);
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (poolManagertransform.childCount > 0)
                        {
                            obj = poolManagertransform.GetChild(0).gameObject;
                            obj.SetActive(true);
                        }
                        else
                        {
                            obj = Instantiate(Bullet, transform);
                        }
                        obj.transform.SetParent(null);

                        BDir = obj.gameObject.GetComponent<BlueBullet>();
                        BDir.SetDir(j, 2, 2, gameObject);
                        obj.transform.position = transform.position;

                    }
                    yield return new WaitForSeconds(1f);
                }
                JimballBoom = false;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
    
}
