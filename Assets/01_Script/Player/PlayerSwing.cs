using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour
{
    float currentTime;
    bool isAble;
    Animator animator;
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
            
        }
        currentTime += Time.deltaTime;
        gameObject.GetComponent<BoxCollider2D>().enabled = currentTime > 0.3f ? false : true;
        isAble = currentTime > 1f ? false : true;

    }
}
