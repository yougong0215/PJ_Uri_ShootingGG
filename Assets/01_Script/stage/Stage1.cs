using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stage1 : MonoBehaviour
{
    CrazyBirdType crazyBird;
    JimBallType jimball;
    WillType will;
    TurletType turlet;


    bool _Patun;

    float currentTime;
    void Start()
    {
        _Patun = true;
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {



    }

    private void LateUpdate()
    {
        currentTime += Time.deltaTime;
    }
}
