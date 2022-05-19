using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��������Ʈ�� �־��ָ�� ( �ֻ��� �θ� ���� )
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
