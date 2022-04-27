using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingAtt_Pull : MonoBehaviour
{
    private Vector3 dir = Vector3.up;
    [SerializeField] float speed = 10;

    void Start()
    {
        StartCoroutine("DisableWing");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += speed * dir * Time.deltaTime;
    }

    IEnumerable DisableWing()
    {
        yield return new WaitForSeconds(3.0f);
        gameObject.SetActive(false);
    }
}


