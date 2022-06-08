using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSwing : MonoBehaviour
{
    float currentTime;
    bool isAble;
    Animator animator;
    [SerializeField] Image Attack;
    [SerializeField] Image Slash;
    BulletTrans bulletTrans;
    float SlashNum;

    // Start is called before the first frame update
    void Start()
    {
        
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
        
    }

    void NormalAttack()
    {
        if (Input.GetKeyDown(KeyCode.X) && isAble == false)
        {
            animator.SetTrigger("swing");
            currentTime = 0;
            isAble = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            Attack.fillAmount = 1;
            Slash.fillAmount += 0.5f;
        }
        currentTime += Time.deltaTime;
        Attack.fillAmount -= Time.deltaTime;
        gameObject.GetComponent<BoxCollider2D>().enabled = currentTime > 0.3f ? false : true;
        isAble = currentTime > 1f ? false : true;
    }

    void WindSlash()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Slash.fillAmount == 1)
        {
            SlashNum = 0;
            animator.SetTrigger("swing");
            bulletTrans = PoolManager.Instance.Pop("WindSlash");
            bulletTrans.transform.position = transform.position;
            Slash.fillAmount = 0;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<BulletTrans>().GetDamage(30);
    }
}
