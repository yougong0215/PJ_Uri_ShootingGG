using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet_Pull : MonoBehaviour
{
    private Vector3 dir = Vector3.up;
    [SerializeField]float speed = 5;

    void Start()
    {
        StartCoroutine("DisableBullet");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += speed * dir * Time.deltaTime;
    }

    IEnumerable DisableBullet()
    {
        
        yield return new WaitForSeconds(5.0f);
        gameObject.SetActive(false);
    }
}
