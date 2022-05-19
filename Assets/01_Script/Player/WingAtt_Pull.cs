using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingAtt_Pull : MonoBehaviour
{
    private Vector3 dir = Vector3.up;
    [SerializeField] float speed = 10;
    [SerializeField] float currentTime = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        FalseBullet();
        transform.position += speed * dir * Time.deltaTime;
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


