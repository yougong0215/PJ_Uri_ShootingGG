using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingAtt_Pull : MonoBehaviour
{
    private Vector3 dir = Vector3.up;
    [SerializeField] float speed = 10;
    [SerializeField] float currentTime = 0;
    bool Born = false;
    Vector3 wingps;

    // Update is called once per frame
    void FixedUpdate()
    {
        FalseBullet();
        ScaleCheck();
        transform.position += speed * dir * Time.deltaTime;
    }
    void ScaleCheck()
    {
        if (currentTime >= 2f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (currentTime < 2f && currentTime >= 1f)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        }
        else if (currentTime < 1f && currentTime >= 0f)
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 1f);
        }
    }

    public void SetCurrentTime(float currentTimes) 
    { 
        currentTime = currentTimes;
    }

    void FalseBullet()
    {
        if (Mathf.Abs(transform.position.y) >= 5)
        {
            gameObject.SetActive(false);
        }

    }
}


