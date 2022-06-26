using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    int HP =10;
    protected bool oncurrt;
    float currentTime;
    PlayerItem powers;
    AudioSource _audio;
    [SerializeField]AudioClip _clip;
    [SerializeField] Image HP1;
    [SerializeField] Image HP2;
    [SerializeField] Image HP3;
    [SerializeField] Image HP4;
    [SerializeField] Image HP5;

    public bool GetOnCR()
    {
        return oncurrt;
    }
    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        powers = GameObject.Find("Player").GetComponent<PlayerItem>();
        currentTime = 0;
      
        oncurrt = false;
        HP = 10;
    }

    // Update is called once per frame
    void Update()
    {

        if (currentTime >= 1.5f && oncurrt == false)
        {
            oncurrt = true;
        }
        else
        {
            currentTime += Time.deltaTime;
        }
        HPing();
      
    }

    void HPing()
    {
        switch (HP)
        {
            case 0:
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
                break;
            case 1:
                HP1.fillAmount = 0.5f;
                HP2.fillAmount = 0;
                HP3.fillAmount = 0;
                HP4.fillAmount = 0;
                HP5.fillAmount = 0;
                break;
            case 2:
                HP1.fillAmount = 1f;
                HP2.fillAmount = 0;
                HP3.fillAmount = 0;
                HP4.fillAmount = 0;
                HP5.fillAmount = 0;
                break;
            case 3:
                HP1.fillAmount = 1f;
                HP2.fillAmount = 0.5f;
                HP3.fillAmount = 0;
                HP4.fillAmount = 0;
                HP5.fillAmount = 0;
                break;
            case 4:
                HP1.fillAmount = 1f;
                HP2.fillAmount = 1f;
                HP3.fillAmount = 0;
                HP4.fillAmount = 0;
                HP5.fillAmount = 0;
                break;
            case 5:
                HP1.fillAmount = 1f;
                HP2.fillAmount = 1f;
                HP3.fillAmount = 0.5f;
                HP4.fillAmount = 0;
                HP5.fillAmount = 0;
                break;
            case 6:
                HP1.fillAmount = 1f;
                HP2.fillAmount = 1f;
                HP3.fillAmount = 1f;
                HP4.fillAmount = 0;
                HP5.fillAmount = 0;
                break;
            case 7:
                HP1.fillAmount = 1f;
                HP2.fillAmount = 1f;
                HP3.fillAmount = 1f;
                HP4.fillAmount = 0.5f;
                HP5.fillAmount = 0;
                break;
            case 8:
                HP1.fillAmount = 1f;
                HP2.fillAmount = 1f;
                HP3.fillAmount = 1f;
                HP4.fillAmount = 1f;
                HP5.fillAmount = 0;
                break;
            case 9:
                HP1.fillAmount = 1f;
                HP2.fillAmount = 1f;
                HP3.fillAmount = 1f;
                HP4.fillAmount = 1f;
                HP5.fillAmount = 0.5f;
                break;
            case 10:
                HP1.fillAmount = 1f;
                HP2.fillAmount = 1f;
                HP3.fillAmount = 1f;
                HP4.fillAmount = 1f;
                HP5.fillAmount = 1f;
                break;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"{GameManager.Instance.GetDamaged()} | {oncurrt}");
        if (collision.GetComponent<BulletTrans>() && oncurrt == true)
        {
            powers.HitPowerCnt();
                HP--;
                oncurrt = false;
                Debug.Log(HP);
            currentTime = 0;
            _audio.PlayOneShot(_clip);
        }
    }
}
