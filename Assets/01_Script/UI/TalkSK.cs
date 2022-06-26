using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class TalkSK : MonoBehaviour
{
    int talkint;
    [SerializeField] List<string> Talking;
    BackgroundSound _BGsound;
    TextMeshProUGUI TalkText;
    Image _Panel;
    private void Awake()
    {
        TalkText = GameManager.Instance.TextGUI();
        _Panel = GameManager.Instance.TextPanel();
        _BGsound = GameObject.Find("Background").GetComponent<BackgroundSound>();
    }
    bool skipText = false;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Z))
        {
            skipText = true;
        }
    }
    public void TalkingS()
    {
        talkint = 0;
        StartCoroutine(TalkingStart());
    }

    Sequence seq;
    public IEnumerator TalkingStart()
    {

        _Panel.rectTransform.localPosition = new Vector3(-280, -280, 0);
        while (true)
        {
            TalkText.text = "";
            
            TalkText.DOText(Talking[talkint], 1f);
            yield return new WaitForSeconds(0.5f);
            if (skipText == true)
            {
                TalkText.DOKill();
                TalkText.text = "";
                yield return new WaitForSeconds(1f);
            }


            skipText = false;
            talkint++;


            if(talkint == Talking.Count)
            {
                break;
            }
            TalkText.DOKill();
        }
        _BGsound.PlayNext();
        _Panel.rectTransform.DOMoveY(-900, 1f);
    }
}
