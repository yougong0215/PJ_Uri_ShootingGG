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
    Vector3 first = new Vector3(-2000, 537,0);
    Vector3 second = new Vector3(600, 537, 0);
    Vector3 third = new Vector3(1200, 537, 0);
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
    
    private void OnEnable()
    {
        DOTween.KillAll();
    }
    public int GetModeselect()
    {
        return ModeSelect;
    }
    public int Getdiffselect()
    {
        return diff;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log($"{SMQ} |  {diff}");
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
                    PlayingUI.position = second;
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
                        PlayingUI.position = first;
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


                        DiffSElectUI.position = third;
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

                        DiffSElectUI.position = first;
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
                    MofiUI.position = second;
                }
                if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Escape))
                {
                    _select = false;
                    _seeing = false;
                    MofiUI.position = first;
                }
            }
            else if (SMQ == 3)
            {
            }
        }
    }
}

/*
 *  void moveing()
    {
        UIMoveTime += Time.deltaTime;
        if (bPlayingUI == true&& SMQ == 1)
        {
            PlayingUI.position = Vector3.Lerp(transform.position, SecondPos, UIMoveTime);
        }
        else if(bPlayingUI == false && SMQ == 1)
        {
            PlayingUI.position = Vector3.Lerp(transform.position, FirstPos, UIMoveTime);
        }
        if (bDiffUI == true && SMQ == 1)
        {
            DiffSElectUI.position = Vector3.Lerp(transform.position, new Vector3(1200, 580, 0), UIMoveTime);
        }
        else if(bDiffUI == false && SMQ == 1)
        {
            DiffSElectUI.position = Vector3.Lerp(transform.position, FirstPos, UIMoveTime); ;
        }
        if(bMofiUI == true && SMQ == 2)
        {
            MofiUI.position = Vector3.Lerp(transform.position, SecondPos, UIMoveTime);
        }
        else if(bMofiUI == false && SMQ == 2)
        {
            MofiUI.position = Vector3.Lerp(transform.position, FirstPos, UIMoveTime);
        }
    }
 * */