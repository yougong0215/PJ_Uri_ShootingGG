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

    IEnumerator poolTest()
    {
        while(true)
        {
            GameObject obj1 = null;
            for (i = 0; i < transform.childCount; i++)
            {
                
                if (transform.GetChild(i).gameObject.activeSelf == false && i < transform.childCount)
                {
                    obj1 = transform.GetChild(i).gameObject;
                    obj1.SetActive((true));
                    break;
                }
            }
            if (i == transform.childCount)
            {
                obj1 = Instantiate(obj);
                obj1.transform.SetParent(gameObject.transform);
                obj1.gameObject.name = obj.gameObject.name.Replace("(Clone)", "");
               
            }
            obj1.transform.position = new Vector3(Random.Range(0, 6), -5f, 0);
            yield return new WaitForSeconds(0.5f);

        }
    }
}
