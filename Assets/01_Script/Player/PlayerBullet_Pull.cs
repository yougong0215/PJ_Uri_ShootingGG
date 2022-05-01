using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet_Pull : MonoBehaviour
{
    private Vector3 dir = Vector3.up;
    [SerializeField]float speed = 5;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += speed * dir * Time.deltaTime;
        if(transform.position.y >= 4)
        {
            gameObject.SetActive(false);
            transform.SetParent(GameManager.InstancePro.PoolManagerpro.transform);
        }
    }


}
