using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]int HP =3;
    protected bool oncurrt;
    float currentTime;
    PlayerItem powers;


    public bool GetOnCR()
    {
        return oncurrt;
    }
    // Start is called before the first frame update
    void Start()
    {
        powers = GameObject.Find("Player").GetComponent<PlayerItem>();
        currentTime = 0;
      
        oncurrt = false;
        HP = 3;
    }

    // Update is called once per frame
    void Update()
    {

        if (currentTime >= 1.5f && oncurrt == false)
        {
            oncurrt = true;
        }
        else
        {
            currentTime += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"{GameManager.Instance.GetDamaged()} | {oncurrt}");
        if (collision.GetComponent<BulletTrans>() && oncurrt == true)
        {
            powers.HitPowerCnt();
                HP--;
                oncurrt = false;
                Debug.Log(HP);
            currentTime = 0;
        }
    }
}
