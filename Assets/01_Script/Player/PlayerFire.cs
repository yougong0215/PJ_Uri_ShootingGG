using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Delay());
    }
    BulletTrans Bullet;
    // Update is called once per frame


    IEnumerator Delay()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            if (Input.GetKey(KeyCode.Z))
            {
                if (gameObject.name == "Dark")
                    Bullet = PoolManager.Instance.Pop("DarkArr");
                else if (gameObject.name == "Light")
                    Bullet = PoolManager.Instance.Pop("LightArr");

                Bullet.transform.position = transform.position;
            }
        }
    }



}
