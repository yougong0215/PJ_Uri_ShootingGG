using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    CrazyBirdType CBT;
    float h = 0f;
    float v = 0f;
    Vector3 dir;
    private void Awake()
    {
        // 죽음 받을 예정
    }




    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        dir = new Vector3(h, v, 0);
        if (Input.GetKey(KeyCode.LeftShift))
        {

            transform.position += dir * speed * Time.deltaTime /4;
        }
        else
        {
            transform.position += dir * speed * Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0))
        {
            CBT = PoolManager.Instance.Pop("CrazyBirdType1") as CrazyBirdType;
            CBT.transform.position = new Vector3(0, 5, 0);
            CBT = PoolManager.Instance.Pop("CrazyBirdType2") as CrazyBirdType;
            CBT.transform.position = new Vector3(-4, 5, 0);
            PoolManager.Instance.Pop("Turlet");
        }

    }
}
