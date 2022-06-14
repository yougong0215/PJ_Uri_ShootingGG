using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tests : MonoBehaviour
{
    Vector2 dir;
    float speed = 3;
    float currentTime;
    Vector2 Now;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        dir = Vector3.zero;
        transform.position = new Vector3(5, -5, 0);
        Now = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        currentTime += Time.deltaTime;
        dir.x = Mathf.Sin(currentTime);// + Mathf.Tan(currentTime);
        transform.position = Now + dir;
        Now += new Vector2(0, 1f) * speed * Time.deltaTime;
        */
        currentTime += Time.deltaTime;
        transform.position += Vector3.up * 3 * Time.deltaTime;
        if(currentTime >= 4f)
        {
            gameObject.SetActive(false);
        }
    }

}
