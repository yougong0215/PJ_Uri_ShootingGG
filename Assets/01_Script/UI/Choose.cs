using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Choose : MonoBehaviour
{
    int SMQ = 1;
    int ModeSelect = 1;
    int diff = 2;
    bool _select = false;
    bool _seeing = false;
    bool _diffsel = true;
    float currentTIme = 0;
    TextMeshProUGUI ThisImage = null;


    [SerializeField] TextMeshProUGUI Starts;
    [SerializeField] TextMeshProUGUI Mofi;
    [SerializeField] TextMeshProUGUI Quit;


    [SerializeField] RectTransform MofiUI;



    [SerializeField] RectTransform PlayingUI;
    [SerializeField] TextMeshProUGUI Normal;
    [SerializeField] TextMeshProUGUI Mingun;
    [SerializeField] TextMeshProUGUI Sword;

    [SerializeField] RectTransform DiffSElectUI;
    [SerializeField] TextMeshProUGUI Easy;
    [SerializeField] TextMeshProUGUI Deafult;
    [SerializeField] TextMeshProUGUI Hard;

    public int GetModeselect()
    {
        return ModeSelect;
    }
    // Update is called once per frame
    void Update()
    {
        if (_select == false)
        {
            if (SMQ == 1)
            {
                Starts.color = new Color(255, 0, 0);
                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    SMQ = 2;
                }
                Mofi.color = new Color(255, 255, 255);
                Quit.color = new Color(255, 255, 255);
                if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return))
                {
                    _select = true;
                }
            }
            else if (SMQ == 2)
            {
                Mofi.color = new Color(255, 0, 0);
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    SMQ = 1;
                }
                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    SMQ = 3;
                }
                Starts.color = new Color(255, 255, 255);
                Quit.color = new Color(255, 255, 255);

                if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return))
                {
                    _select = true;
                }
            }
            else if (SMQ == 3)
            {
                Quit.color = new Color(255, 0, 0);
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    SMQ = 2;
                }
                Starts.color = new Color(255, 255, 255);

                Mofi.color = new Color(255, 255, 255);
                if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return))
                {
#if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
                }
            }
        }
        else if (_select == true)
        {
            if (SMQ == 1)
            {
                if (_seeing == false)
                {
                    Starts.color = new Color(0, 255, 0);
                    _seeing = true;
                    PlayingUI.DOMoveX(600, 1f).SetEase(Ease.OutQuad);
                }
                if (_diffsel == true)
                {
                    switch (ModeSelect)
                    {
                        case 1:

                            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                            {
                                ModeSelect = 2;
                            }
                            Normal.color = new Color(255, 0, 0);
                            Mingun.color = new Color(255, 255, 255);
                            Sword.color = new Color(255, 255, 255);
                            ThisImage = Normal;
                            break;
                        case 2:
                            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                            {
                                ModeSelect = 1;
                            }
                            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                            {
                                ModeSelect = 3;
                            }
                            Normal.color = new Color(255, 255, 255);
                            Mingun.color = new Color(255, 0, 0);
                            Sword.color = new Color(255, 255, 255);
                            ThisImage = Mingun;
                            break;
                        case 3:
                            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                            {
                                ModeSelect = 2;
                            }
                            Normal.color = new Color(255, 255, 255);
                            Mingun.color = new Color(255, 255, 255);
                            Sword.color = new Color(255, 0, 0);
                            ThisImage = Sword;
                            break;


                    }

                    if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Escape))
                    {
                        _select = false;
                        _seeing = false;
                        PlayingUI.DOMoveX(-2000, 2f).SetEase(Ease.OutQuad);
                    }
                    if ((Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return)) && _diffsel == true)
                    {
                        if(ThisImage == Normal)
                        {
                            Normal.color = new Color(0, 255, 0);
                        }
                        if (ThisImage == Mingun)
                        {
                            Mingun.color = new Color(0, 255, 0);
                        }
                        if (ThisImage == Sword)
                        {
                            Sword.color = new Color(0, 255, 0);
                        }


                        DiffSElectUI.DOMoveX(1200, 1f).SetEase(Ease.OutQuad);
                        _diffsel = false;
                        currentTIme = 0;
                    }
                }

                if (_diffsel == false)
                {
                    currentTIme += Time.deltaTime;
                    switch (diff)
                    {
                        case 1:

                            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                            {
                                diff = 2;
                            }
                            Easy.color = new Color(255, 0, 0);
                            Deafult.color = new Color(255, 255, 255);
                            Hard.color = new Color(255, 255, 255);
                            break;
                        case 2:
                            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                            {
                                diff = 1;
                            }
                            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                            {
                                diff = 3;
                            }
                            Easy.color = new Color(255, 255, 255);
                            Deafult.color = new Color(255, 0, 0);
                            Hard.color = new Color(255, 255, 255);
                            break;
                        case 3:
                            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                            {
                                diff = 2;
                            }
                            Easy.color = new Color(255, 255, 255);
                            Deafult.color = new Color(255, 255, 255);
                            Hard.color = new Color(255, 0, 0);
                            break;


                    }
                    if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Escape))
                    {

                        DiffSElectUI.DOMoveX(-2000, 1f).SetEase(Ease.OutQuad);
                        _diffsel = true;
                    }
                    if (currentTIme >= 0.1f && (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return)))
                    {
                        SceneManager.LoadScene("Stage1");
                    }
                }

                
               





            }
            else if (SMQ == 2)
            {
                if (_seeing == false)
                {
                    Mofi.color = new Color(0, 255, 0);
                    _seeing = true;
                    MofiUI.DOMoveX(600, 1f).SetEase(Ease.OutQuad);
                }
                if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Escape))
                {
                    _select = false;
                    _seeing = false;
                    MofiUI.DOMoveX(-2000, 2f).SetEase(Ease.OutQuad);
                }
            }
            else if (SMQ == 3)
            {
            }
        }
    }
}
