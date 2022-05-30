using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBulding : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.down * 0.6f * Time.deltaTime;
        if (transform.localPosition.y <= -1f)
        {
            transform.localPosition = new Vector3(0, 1.2f, -5);
        }
    }
}
