using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    int HP =3;
    protected bool oncurrt;
    private bool onDamaged;
    float currentTime;

    public void SetBool()
    {
        onDamaged = false;
    }

    public bool GetOnCR()
    {
        return oncurrt;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        oncurrt = false;
        onDamaged = true;
        HP = 3;
    }

    // Update is called once per frame
    void Update()
    {

        if (currentTime >= 1.5f &&  onDamaged == false)
        {
            onDamaged = true;
            oncurrt = true;
            currentTime = 0;
        }
        else
        {
            oncurrt = false;
            currentTime += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"{GameManager.Instance.GetDamaged()} | {oncurrt}");
        if (collision.GetComponent<BulletTrans>() && onDamaged && oncurrt == true)
        {
                HP--;
                oncurrt = true;
                Debug.Log(HP);
        }
    }
}
