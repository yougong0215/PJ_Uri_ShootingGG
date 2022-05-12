using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundVector : MonoBehaviour
{
  //  [SerializeField] private BlueBullet Bullet;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Vector3 dir;
    Vector3 Seting;
    float minusX; // 트루 = 음수 
    float  minusY;
    float DirRotation;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            BlueBullet Bullet = collision.gameObject.GetComponent<BlueBullet>();
            Seting = Bullet.GetDir();
            /*
            minusX = Seting.x;
            minusY = Seting.y;

            if (minusX == 1 && minusY == 1)
                DirRotation = Random.Range(100f, 170f);
            if (minusX == -1 && minusY == 1)
                DirRotation = Random.Range(80f, 10f);
             if (minusX == -1 && minusY == -1)
                DirRotation = Random.Range(280f, 350f);
            if (minusX == 1 && minusY == -1)
                DirRotation = Random.Range(190f, 260f);
            

            dir = Quaternion.AngleAxis(90f, Vector3.forward) * Bullet.GetDir();
                */
            dir = Vector3.Reflect(Bullet.GetDir(), ((Vector2)transform.position - collision.contacts[0].point).normalized);

            Debug.Log(dir);
            Bullet.SetDir(dir) ;
        }

    }
}
