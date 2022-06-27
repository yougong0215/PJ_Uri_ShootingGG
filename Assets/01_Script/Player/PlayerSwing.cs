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
    [SerializeField] Image NovaGage;
    Slash bulletTrans;
    float SlashNum;
    int SuperNovaCnt;
    bool Check;
    float speed;
    SceneData _SC;

    // Start is called before the first frame update
    void Start()
    {
        _SC = GameObject.Find("StartData").GetComponent<SceneData>();
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
        NovaGage.fillAmount += Time.deltaTime / 30;

        if (_SC.GetModeData() == 1)
        {
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.3f, 0.3f);
        }
        if (_SC.GetModeData() == 3)
        {
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.5f, 0.5f);
        }
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

                if (_SC.GetModeData() == 3 && Random.Range(0, 101) <= _pitem.GetPowerCnt())
                {

                    StartCoroutine(MSlashing());
                }

            }


            animator.SetTrigger("swing");
            currentTime = 0;
            isAble = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            Attack.fillAmount = 1;
            if (_SC.GetDiff() == 1)
            {
                speed *= 1.5f;
            }
            if (_SC.GetDiff() == 2)
            {
                speed *= 1.2f;
            }
            if (_SC.GetDiff() == 3)
            {
                speed *= 1f;
            }
            Slash.fillAmount += speed;
        }
        currentTime += Time.deltaTime;
        Attack.fillAmount -= Time.deltaTime;
        gameObject.GetComponent<BoxCollider2D>().enabled = currentTime > 0.3f ? false : true;
        isAble = currentTime > 1 ? false : true;
    }

    void WindSlash()
    {
        if (_SC.GetModeData() == 1 || _SC.GetModeData() == 3)
        {
            if (Input.GetKeyDown(KeyCode.Space) && Slash.fillAmount == 1)
            {
                SlashNum = 0;
                animator.SetTrigger("swing");
                if (Random.Range(0, 101) <= _pitem.GetPowerCnt())
                {
                    if (_SC.GetDiff() == 1 || _SC.GetDiff() == 2)
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
                else
                {

                    bulletTrans = PoolManager.Instance.Pop("WindSlash") as Slash;
                    bulletTrans.transform.position = transform.position;
                    bulletTrans.SetDirH(1);
                }
                Slash.fillAmount = 0;

            }
        }
        if (_SC.GetModeData() == 3)
        {
            swordMofi = 2;
        }

    }
    IEnumerator Slashings()
    {
        for (int i = 0; i < 10; i++)
        {
            StartCoroutine(MSlashing());
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Slashing());
        NovaCheck = false;
    }
    IEnumerator MSlashing()
    {
        for (int j = 1; j <= 3; j++)
        {
            bulletTrans = PoolManager.Instance.Pop("MiniSlash") as Slash;
            bulletTrans.transform.position = transform.position;
            bulletTrans.SetDirH(j);
            yield return new WaitForEndOfFrame();
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
    public bool GetNova()
    {
        return NovaCheck;
    }
    bool NovaCheck;
    bool MiniSuper = false;
    void SuperNove()
    {
        if (NovaGage.fillAmount == 1 && Input.GetKeyDown(KeyCode.C))
        {
            if (_SC.GetModeData() == 1)
            {
                NovaGage.fillAmount = 0;
                Explosion.transform.GetChild(1).gameObject.SetActive(true);
                Explosion.transform.GetChild(0).gameObject.SetActive(true);

            }
            if (_SC.GetModeData() == 2 && MiniSuper == false)
            {
                MiniSuper = true;
                Explosion.transform.GetChild(0).gameObject.SetActive(true);
            }

            if (_SC.GetModeData() == 3)
            {
                NovaCheck = true;
                StartCoroutine(Slashings());
                NovaGage.fillAmount = 0;
                Explosion.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        if(MiniSuper == true)
        {
            SUperTime += Time.deltaTime;
            if(SUperTime >= 0.1f)
            {
                NovaGage.fillAmount -= 0.025f;
                SUperTime = 0;
            }
        }
        if(NovaGage.fillAmount == 0 )
        {
            MiniSuper = false;
        }
    }
    float SUperTime =0;
    int swordMofi = 1;
    public bool GetSuperMofe()
    {
        return MiniSuper;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        collision.gameObject.GetComponent<BulletTrans>().GetDamage(10 + _pitem.GetPowerCnt() * swordMofi);
        if (collision.GetComponent<BlueBullet>() || collision.GetComponent<BaeYaShoot>())
        {
            PoolManager.Instance.Push(collision.gameObject.GetComponent<BulletTrans>());
        }
    }

}
