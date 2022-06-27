using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndData : MonoBehaviour
{
    SceneData _SC;
    [SerializeField] TextMeshProUGUI Game;
    [SerializeField] TextMeshProUGUI Score;
    [SerializeField] TextMeshProUGUI Mode;
    [SerializeField] TextMeshProUGUI Time;
    [SerializeField] TextMeshProUGUI Diff;
    [SerializeField] TextMeshProUGUI Again;
    [SerializeField] TextMeshProUGUI Stop;
    int AgainStop;
    int Modname;
    int Difname;
    void Start()
    {
        _SC = GameObject.Find("StartData").GetComponent<SceneData>();
        Modname = _SC.GetModeData();
        Difname = _SC.GetDiff();
    }
    bool clear= false;
    // Update is called once per frame
    void Update()
    {
        try
        {
            clear = _SC.Getclear();
            Debug.Log($"{Modname} {Difname}");
            switch (Modname)
            {
                case 1:
                    Mode.text = $"PlayMode : 일반";
                    break;
                case 2:
                    Mode.text = $"PlayMode : 난사";
                    break;
                case 3:
                    Mode.text = $"PlayMode : 검객";
                    break;
            }
            switch (Difname)
            {
                case 1:
                    Diff.text = $"Difficult : 이즤";
                    break;
                case 2:
                    Diff.text = $"Difficult : 노말";
                    break;
                case 3:
                    Diff.text = $"PlayMode : Hard";
                    break;
            }
            if(clear == true)
            {
                Game.text = "Game Clear";
            }
            else
            {
                Game.text = "Game Over";

            }
            Score.text = $"PlayScore : {PlayerPrefs.GetInt("Score", 0)} / {PlayerPrefs.GetInt("HighScore", 0)}";
            Time.text = $"PlayTime : {_SC.GetCurrentTime()}";
            Destroy(_SC.gameObject);
        }
        catch
        {

        }

        if (AgainStop == 1)
        {
            Again.color = new Color(255, 0, 0);
            Stop.color = new Color(255, 255, 255);
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                AgainStop = 2;
            }
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Start");
            }
        }
        if (AgainStop == 2)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                AgainStop = 1;
            }
            Again.color = new Color(255, 255, 255);
            Stop.color = new Color(255, 0, 0);
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return))
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
            }
        }
        if (AgainStop >= 2)
        {
            AgainStop = 2;
        }
        if (AgainStop <= 1)
        {
            AgainStop = 1;
        }

    }
}
