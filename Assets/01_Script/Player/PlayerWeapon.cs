using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] float speed;
    Vector2 pos1;
    Vector2 pos2;

    private void Start()
    {
        pos1 = Vector2.Lerp(new Vector2(-0.1f, -0.15f), new Vector2(0.1f, -0.15f), Time.deltaTime/5);
        pos2 = Vector2.Lerp(new Vector2(0.1f, -0.15f), new Vector2(-0.1f, -0.15f), Time.deltaTime/5);
        StartCoroutine("A");
    }
    IEnumerator A()
    {
        transform.position = pos1;
        yield return new WaitForSeconds(1f);
        transform.position = pos2;
        yield return new WaitForSeconds(1f);
        StartCoroutine("A");
    }
}
