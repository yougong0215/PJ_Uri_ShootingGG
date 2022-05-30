using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    int HP =3;
    protected float currt;
    protected bool oncurrt;
    private bool attacked;



    public float GetCRTime()
    {
        return currt;
    }
    public bool GetOnCR()
    {
        return oncurrt;
    }
    // Start is called before the first frame update
    void Start()
    {
        oncurrt = false;
        currt = 0;
        HP = 3;
    }

    // Update is called once per frame
    void Update()
    {
       if(oncurrt == true)
        {
            currt += Time.deltaTime;
        }

       if(currt >= 1)
        {
            oncurrt = false;    
            currt = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"{GameManager.Instance.GetDamaged()} | {oncurrt}");
        if (collision.gameObject.CompareTag("Item") == false && oncurrt == false)
        {
                HP--;
                oncurrt = true;
            Debug.Log(collision.name);
                Debug.Log(HP);
        }
    }
}
