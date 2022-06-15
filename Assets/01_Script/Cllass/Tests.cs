using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tests : MonoBehaviour
{
    Vector3 dir;
    float speed = 3;
    float currentTime;
    Vector2 Now;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        dir = Vector3.zero;
        //transform.position = new Vector3(5, -5, 0);
        Now = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        currentTime += Time.deltaTime;
        
        transform.position = Now + dir;
        Now += new Vector2(0, 1f) * speed * Time.deltaTime;
        */
        dir.x = Mathf.Sin(currentTime * 2);// + Mathf.Tan(currentTime);
        dir.y = 1f;
        currentTime += Time.deltaTime;
        transform.position += dir * 3 * Time.deltaTime;
        if(currentTime >= 4f)
        {
            currentTime = 0;
            gameObject.SetActive(false);
        }
    }

}
