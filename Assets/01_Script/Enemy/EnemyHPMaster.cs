using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 스프라이트에 넣어주면됨 ( 최상위 부모 말고 )
/// </summary>
public class EnemyHPMaster : EnemyParent
{
    [SerializeField] private int HP;

    void Awake()
    {
        // 씬 / 적에 따라 다르게 하자
        HP = 100;
    }

    private void Update()
    {
        if(HP <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            HP--;
            collision.gameObject.SetActive(false);
            collision.transform.SetParent(GameManager.InstancePro.PoolManagerpro.transform);
        }
    }
}
