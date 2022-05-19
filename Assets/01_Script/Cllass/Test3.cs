using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Test3 : MonoBehaviour
{
    private delegate int Sans();
    private event Sans dele;
    private delegate void Sans2();
    private event Sans2 dele2;

    private Action myAction = null;

    public UnityEvent myEvent = null;

    int HP = 3;
    int ATK = 5;


    private void Start()
    {
        myAction += Damage;
        myAction += ATTACK;

        myAction?.Invoke();
        // nullable 문법 ( null 이여도 가능 )

        dele += jaeea1;
        dele += jaeea2;
        dele += jaeea3;
        dele();

        myEvent.AddListener(Damage);
        myEvent.RemoveListener(Damage);

        myEvent.AddListener(() => {   HP--; });
    }
    public void Damage()
    {
        HP--;
    }
    public void ATTACK()
    {
        ATK++;
    }

    private int jaeea1()
    {
        Debug.Log("1");
        return 1;
    }
    private int jaeea2()
    {
        Debug.Log("2");
        return 1;
    }
    private int jaeea3()
    {
        Debug.Log("3");
        return 1;
    }
}
