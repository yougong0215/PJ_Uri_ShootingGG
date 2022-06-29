using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class TalkSK : MonoBehaviour
{
    int talkint;
    float currentTime;
    [SerializeField] List<string> Talking;
    BackgroundSound _BGsound;
    TextMeshProUGUI TalkText;
    AudioSource _audio;
    Image _Panel;
    bool Sounds = false;
    private void Awake()
    {
        TalkText = GameManager.Instance.TextGUI();
        _Panel = GameManager.Instance.TextPanel();
        _BGsound = GameObject.Find("Background").GetComponent<BackgroundSound>();
    }
    private void Start()
    {
        TalkText.text = "";
    }
    bool skipText = false;
    private void Update()
    {
        TalkingS();
    }
    public void TalkingS()
    {
        if (talkint < Talking.Count)
        {
            if (currentTime >= 2f)
            {
                currentTime = 0;
                TalkText.DOKill();
                _Panel.rectTransform.localPosition = new Vector3(-280, -280, 0);
                TalkText.DOText(Talking[talkint], 2f).OnComplete(() => { TalkText.text = ""; });
                talkint++;
            }
            else
            {
                currentTime += Time.deltaTime;
            }

            if ((Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return) )&& currentTime>=0.3f)
            {
                TalkText.text = "";
                TalkText.DOKill();
                currentTime += 2;
            }
        }

        if (talkint == Talking.Count && Sounds == false)
        {
            Sounds = true;
            _BGsound.PlayNext();
            _Panel.rectTransform.DOMoveY(-900, 1f);
        }
    }
}
