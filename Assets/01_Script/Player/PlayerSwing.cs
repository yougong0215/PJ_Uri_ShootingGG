using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSwing : MonoBehaviour
{
    float currentTime;
    bool isAble;
    Animator animator;
    [SerializeField] Image image;
    BulletTrans bulletTrans;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        currentTime = 0;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isAble == false)
        {
            animator.SetTrigger("swing");
            currentTime = 0;
            isAble = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            image.fillAmount = 1;
            
        }
        currentTime += Time.deltaTime;
        image.fillAmount -= Time.deltaTime;
        gameObject.GetComponent<BoxCollider2D>().enabled = currentTime > 0.3f ? false : true;
        isAble = currentTime > 1f ? false : true;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<BulletTrans>().GetDamage(30);
        Debug.Log(collision.name);
    }
}
