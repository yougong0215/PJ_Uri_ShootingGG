using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 스프라이트에 넣어주면됨 ( 최상위 부모 말고 )
/// </summary>
public class EnemyHPMaster : EnemyParent
{
    protected int HP;


    private void Update()
    {
        if(HP <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            HP--;
            collision.gameObject.SetActive(false);
            collision.transform.SetParent(GameManager.InstancePro.PoolManagerpro.transform);
        }
    }
}
