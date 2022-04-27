using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerWeaponW : MonoBehaviour
{
    PlayerMove playermove;
    void Awake()
    {
        playermove = GameObject.Find("Player").GetComponent<PlayerMove>();
    }

    private void Start()
    {
        LocalX = playermove.transform.position.x;
        LocalY = playermove.transform.position.y;
        transform.position = new Vector3(LocalX, LocalY, 0);
        StartCoroutine("WhithPosX");
    }
    float LocalX;
    float LocalY;

    IEnumerator DarkPosX()
    {
        yield return new WaitForSeconds(0.2f);
        LocalX = playermove.transform.position.x - 0.8f;
        LocalY = playermove.transform.position.y - 0.72f;
        StartCoroutine("WhithPosX");
        StartCoroutine("WhithPosY");
    }
    IEnumerator WhithPosX()
    {
        yield return new WaitForSeconds(0.2f);
        LocalX = playermove.transform.position.x + 0.2f;
        LocalY = playermove.transform.position.y - 0.72f;
        StartCoroutine("DarkPosX");
        StartCoroutine("DarkPosY");
    }
    IEnumerator DarkPosY()
    {
        yield return new WaitForSeconds(0.1f);
        LocalY = playermove.transform.position.y - 0.36f;
    }
    IEnumerator WhithPosY()
    {
        yield return new WaitForSeconds(0.1f);
        LocalY = playermove.transform.position.y - 1.08f;
    }

    private void Update()
    {
        transform.DOMove(new Vector3(LocalX, LocalY, 0),1f);
    }

    // Update is called once per frame
}
