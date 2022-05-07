using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 pos;
    [SerializeField] GameObject Target;
    [SerializeField] GameObject UP;
    [SerializeField] GameObject Down;
    Vector3 LateWitch;
    Vector3 NowWitch;
    Vector3 UpPs;
    Vector3 DownPs;

    int a;
    private void Start()
    {
        if (gameObject.name == "Dark")
        {
            transform.localPosition = new Vector3(-0.1f, 0, 0);
        }

        if (gameObject.name == "Light")
        {
            transform.localPosition = new Vector3(0.1f, 0, 0);
        }
        UpPs = UP.transform.localPosition;
        DownPs = Down.transform.localPosition;
        LateWitch = Target.transform.localPosition;
        NowWitch = gameObject.transform.localPosition;
            StartCoroutine("A");
    }

    private void Update()
    {
        check();
    }
    IEnumerator A()
    {
        if (gameObject.name == "Dark")
        {
            switch (a)
            {
                case 1:
                    pos = Vector2.MoveTowards(gameObject.transform.localPosition, UpPs, 0.005f);
                    break;
                case 2:
                    pos = Vector2.MoveTowards(gameObject.transform.localPosition, LateWitch, 0.005f);
                    break;
                case 3:
                    pos = Vector2.MoveTowards(gameObject.transform.localPosition, DownPs, 0.005f);
                    break;
                case 4:
                    pos = Vector2.MoveTowards(gameObject.transform.localPosition, NowWitch, 0.005f);
                    break;

                default:
                    break;
            }

        }
        if (gameObject.name == "Light")
        {
            switch (a)
            {
                case 1:
                    pos = Vector2.MoveTowards(gameObject.transform.localPosition, DownPs, 0.005f);
                    break;
                case 2:
                    pos = Vector2.MoveTowards(gameObject.transform.localPosition, NowWitch, 0.005f);
                    break;
                case 3:
                    pos = Vector2.MoveTowards(gameObject.transform.localPosition, UpPs, 0.005f);
                    break;
                case 4:
                    pos = Vector2.MoveTowards(gameObject.transform.localPosition, LateWitch, 0.005f);
                    break;

                default:
                    break;
            }
        }
        yield return new WaitForEndOfFrame();
        transform.localPosition = pos;
        StartCoroutine("A");
    }

    void check()
    {
            if (NowWitch == transform.localPosition)
                a = 1;
            else if (UpPs == transform.localPosition)
                a = 2;
            else if (LateWitch == transform.localPosition)
                a = 3;
            else if (DownPs == transform.localPosition)
                a = 4;
        
    }
}
