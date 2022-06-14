using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPool : MonoBehaviour
{
    [SerializeField] GameObject obj;
    int i;
    private void Start()
    {
        obj = Instantiate(obj, transform.parent);
        obj.transform.parent = gameObject.transform;
        obj.gameObject.name = obj.gameObject.name.Replace("(Clone)", "");
        obj.SetActive(false);
        StartCoroutine(poolTest());
    }

    private void Update()
    {
       
    }

    IEnumerator poolTest()
    {
        while(true)
        {
            for (i = 0; i < transform.childCount; i++)
            {
                Debug.Log($"{i} {transform.childCount} {transform.GetChild(i).gameObject.activeSelf == false}");
                GameObject obj1 = null;
                if (transform.GetChild(i).gameObject.activeSelf == false && i < transform.childCount)
                {
                    obj1 = transform.GetChild(i).gameObject;
                    obj1.SetActive((true));
                    break;
                }
                else if (i == transform.childCount -1)
                {  
                    Debug.Log("»çÀÌÅ¬");
                    obj1 = Instantiate(obj);
                    obj1.transform.SetParent(gameObject.transform);
                    obj1.gameObject.name = obj.gameObject.name.Replace("(Clone)", "");
                    break;
                }
            }
            yield return new WaitForSeconds(0.5f);

        }
    }
}
