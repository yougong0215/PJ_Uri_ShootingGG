using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerWeaponD : MonoBehaviour
{
    Tweener Circle;
    float speed = 3;
    PlayerMove playermove;
    void Awake()
    {
        playermove = GameObject.Find("Player").GetComponent<PlayerMove>();
    }
    void Start()
    {
        LocalX = playermove.transform.position.x;
        LocalY = playermove.transform.position.y;
        transform.position = new Vector3(LocalX, LocalY, 0);
        StartCoroutine("DarkPosX");
        Circle = transform.DOMove(new Vector3(LocalX, LocalY, 0), 1f).SetAutoKill(false);
    }

    float LocalX;
    float LocalY;

    IEnumerator DarkPosX()
    {
        yield return new WaitForSeconds(0.4f);
        LocalX = playermove.transform.position.x - 0.8f;
        LocalY = playermove.transform.position.y - 0.72f;

        StartCoroutine("WhithPosX");
        StartCoroutine("WhithPosY");
    }
    IEnumerator WhithPosX()
    {
        yield return new WaitForSeconds(0.4f);
        LocalX = playermove.transform.position.x + 0.2f;
        LocalY = playermove.transform.position.y - 0.72f;
        StartCoroutine("DarkPosX");
        StartCoroutine("DarkPosY");
    }
    IEnumerator DarkPosY()
    {
        yield return new WaitForSeconds(0.2f);
        LocalY = playermove.transform.position.y - 0.36f;
    }
    IEnumerator WhithPosY()
    {
        yield return new WaitForSeconds(0.2f);
        LocalY = playermove.transform.position.y - 1.08f;
    }

    Vector3 dir;

    private void Update()
    {
        dir = new Vector3(LocalX, LocalY, 0);
        Circle.ChangeEndValue(dir, true).Restart();
    }
}
