using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSwing : MonoBehaviour
{
    float currentTime;
     PlayerItem _pitem;
    bool isAble;
    Animator animator;
    [SerializeField] Image Attack;
    [SerializeField] Image Slash;
    [SerializeField] GameObject Explosion;
    Slash bulletTrans;
    float SlashNum;
    int SuperNovaCnt;
    bool Check;
    float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        _pitem = GameObject.Find("Player").GetComponent<PlayerItem>();
        
        SlashNum = 0;
        animator = gameObject.GetComponent<Animator>();
        currentTime = 0;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        WindSlash();
        NormalAttack();
        SuperNove();
    }


    void NormalAttack()
    {
           

        if ((Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Q)) && isAble == false)
        {

            if (_pitem.GetPowerCnt() >= 0 && _pitem.GetPowerCnt() < 10)
                speed = 0.10f;
            else if (_pitem.GetPowerCnt() >= 10 && _pitem.GetPowerCnt() < 20)
                speed = 0.15f;
            else if (_pitem.GetPowerCnt() >= 20 && _pitem.GetPowerCnt() < 30)
                speed = 0.20f;
            else if (_pitem.GetPowerCnt() >= 30 && _pitem.GetPowerCnt() < 40)
                speed = 0.25f;
            else if (_pitem.GetPowerCnt() >= 40 && _pitem.GetPowerCnt() < 50)
                speed = 0.30f;
            else if (_pitem.GetPowerCnt() >= 50 && _pitem.GetPowerCnt() < 70)
                speed = 0.35f;
            else if (_pitem.GetPowerCnt() >= 60 && _pitem.GetPowerCnt() < 80)
                speed = 0.40f;
            else if (_pitem.GetPowerCnt() >= 70)
            {
                speed = 0.50f;
                if (_pitem.GetPowerCnt() >= 100)
                {
                    bulletTrans = PoolManager.Instance.Pop("WindSlash") as Slash;
                    bulletTrans.transform.position = transform.position;
                    bulletTrans.SetDirH(1);
                }
            }


            animator.SetTrigger("swing");
            currentTime = 0;
            isAble = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            Attack.fillAmount = 1;
            Slash.fillAmount += 1;//speed;
        }
        currentTime += Time.deltaTime;
        Attack.fillAmount -= Time.deltaTime ;
        gameObject.GetComponent<BoxCollider2D>().enabled = currentTime > 0.3f? false : true;
        isAble = currentTime > 1 ? false : true;
    }

    void WindSlash()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Slash.fillAmount == 1)
        {
            SlashNum = 0;
            animator.SetTrigger("swing");
            if(Random.Range(0,101) <= _pitem.GetPowerCnt())
            {
                StartCoroutine(Slashing());
            }
            else
            {

                bulletTrans = PoolManager.Instance.Pop("WindSlash") as Slash;
                bulletTrans.transform.position = transform.position;
                bulletTrans.SetDirH(1);
            }
            Slash.fillAmount = 0;
        }
        
    }
    IEnumerator Slashing()
    {
        for (int j = 1; j <= 3; j++)
        {
            bulletTrans = PoolManager.Instance.Pop("WindSlash") as Slash;
            bulletTrans.transform.position = transform.position;
            bulletTrans.SetDirH(j);
            yield return new WaitForEndOfFrame();
        }
    }
    void SuperNove()
    {
        if (Input.GetKeyDown(KeyCode.C) && Input.GetKey(KeyCode.LeftShift))
        {
            Explosion.transform.GetChild(1).gameObject.SetActive(true);
            Check = true;
        }
        if (Input.GetKeyDown(KeyCode.C) && Check == false)
        {
                Explosion.transform.GetChild(0).gameObject.SetActive(true);
        }
        Check = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        collision.gameObject.GetComponent<BulletTrans>().GetDamage(10 + _pitem.GetPowerCnt() *3);
    }
}
