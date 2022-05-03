using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��������Ʈ�� �־��ָ�� ( �ֻ��� �θ� ���� )
/// </summary>
public class EnemyHPMaster : EnemyParent
{
    [SerializeField] private int HP;

    void Awake()
    {
        // �� / ���� ���� �ٸ��� ����
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
