using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 pos;
    [SerializeField] GameObject Light;
    [SerializeField] GameObject UP;
    [SerializeField] GameObject Down;
    [SerializeField] GameObject Dark;
    Vector3 Lightps;
    Vector3 Darkps;
    Vector3 UpPs;
    Vector3 DownPs;

    int a;
    private void Awake()
    {
        if (gameObject.name == "Dark")
        {
            pos = new Vector3(-0.1f, 0, -1);
        }

        if (gameObject.name == "Light")
        {
            pos = new Vector3(0.1f, 0, -1);
        }

        UpPs = UP.transform.localPosition;
        DownPs = Down.transform.localPosition;
        Lightps = Light.transform.localPosition;
        Darkps = Dark.transform.localPosition;
            StartCoroutine(A());
    }

    private void Update()
    {
        check();
    }
    IEnumerator A()
    {
        while (true)
        {
            if (gameObject.name == "Dark")
            {
                switch (a)
                {
                    case 1:
                        pos = Vector3.MoveTowards(gameObject.transform.localPosition, UpPs, 0.005f);
                        break;
                    case 2:
                        pos = Vector3.MoveTowards(gameObject.transform.localPosition, Lightps, 0.005f);
                        break;
                    case 3:
                        pos = Vector3.MoveTowards(gameObject.transform.localPosition, DownPs, 0.005f);
                        break;
                    case 4:
                        pos = Vector3.MoveTowards(gameObject.transform.localPosition, Darkps, 0.005f);
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
                        pos = Vector3.MoveTowards(gameObject.transform.localPosition, Darkps, 0.005f);
                        break;
                    case 2:
                        pos = Vector3.MoveTowards(gameObject.transform.localPosition, Lightps, 0.005f);
                        break;
                    case 3:
                        pos = Vector3.MoveTowards(gameObject.transform.localPosition, DownPs, 0.005f);
                        break;
                    case 4:
                        pos = Vector3.MoveTowards(gameObject.transform.localPosition, UpPs, 0.005f);
                        break;

                    default:
                        break;
                }
            }
            yield return new WaitForEndOfFrame();
            transform.localPosition = pos;
        }
    }

    void check()
    {
        

            if (gameObject.name == "Dark")
        {
            if (Darkps == transform.localPosition)
                a = 1;
            else if (UpPs == transform.localPosition)
                a = 2;
            else if (Lightps == transform.localPosition)
                a = 3;
            else if (DownPs == transform.localPosition)
                a = 4;
        }
        if (gameObject.name == "Light")
        {
            if (Darkps == transform.localPosition)
                a = 4;
            else if (DownPs == transform.localPosition)
                a = 1;
            else if (Lightps == transform.localPosition)
                a = 3;
            else if (UpPs == transform.localPosition)
                a = 2;
        }


    }
}
