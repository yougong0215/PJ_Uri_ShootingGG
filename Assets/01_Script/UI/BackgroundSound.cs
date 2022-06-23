using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSound : MonoBehaviour
{
    AudioSource _audio;
    Stage1 _stg1;
    [SerializeField] List<AudioClip> _AudioClip;
    TalkSK talkSK;

    int Number;

    void Start()
    {
        Number = 0;
        _stg1 = GameObject.Find("Stage1").GetComponent<Stage1>();
        _audio = GetComponent<AudioSource>();
        _audio.clip = _AudioClip[0];
        _audio.Play();
    }

    public void TalkingStart(string Boss)
    {
        talkSK = GameObject.Find($"GameManager/{Boss}").GetComponent<TalkSK>();
        _audio.Stop();
        _audio.clip = _AudioClip[1];
        talkSK.TalkingS();
    }

    public void PlayNext()
    {
        _audio.Play();
        StartCoroutine(StartFight());
        
    }
    IEnumerator StartFight()
    {
        yield return new WaitForSeconds(2f);
        _stg1.BossGone(false);
    }
    


}
