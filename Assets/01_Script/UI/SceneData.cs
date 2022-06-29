using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneData : MonoBehaviour
{
    [SerializeField] Choose GetData;
    Stage1 stg;
    int Mode = 1;
    int Difficult = 2;
    int currentTime;
    private void Awake()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        DontDestroyOnLoad(this);
    }
    private void Update()
    {
        try
        {
            Mode = GetData.GetModeselect();
            Difficult = GetData.Getdiffselect();
        }
        catch
        {
      
        }

        try
        {
            stg = GameObject.Find("Stage1").GetComponent<Stage1>();
            currentTime = (int)stg.GetGameTime();
        }
        catch
        {

        }
        
    }
    bool clear =false;
    public bool Getclear()
    {
        return clear;
    }
    public void SetClear()
    {
        clear = true;
    }
    public int GetCurrentTime()
    {
        return currentTime;
    }
    public int GetModeData()
    {
        return Mode;
    }
    public int GetDiff()
    {
        return Difficult;
    }
}
