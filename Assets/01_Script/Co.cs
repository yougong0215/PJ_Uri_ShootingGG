using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Co : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Yes());
    }

    IEnumerator Yes()
    {
        while (true)
        {
            // �� ����
            yield return new WaitForSeconds(1f);
        }

    }
}
