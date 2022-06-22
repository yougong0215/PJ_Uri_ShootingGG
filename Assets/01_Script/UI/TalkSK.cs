using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class TalkSK : MonoBehaviour
{
    int talkint;
    [SerializeField]TextMeshProUGUI TalkText;
    [SerializeField] List<string> Talking;

    BackgroundSound _BGsound;

    private void Awake()
    {
        _BGsound = GameObject.Find("BackGround").GetComponent<BackgroundSound>();
    }

    public void TalkingS()
    {
        StartCoroutine(TalkingStart());
    }
    public IEnumerator TalkingStart()
    {
        while (true)
        {

            TalkText.DOText(Talking[talkint], 1f);

            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                continue;
            }
            yield return new WaitForSeconds(3f);



            if(talkint == Talking.Count)
            {
                break;
            }
        }


    }
}
