using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneData : MonoBehaviour
{
    [SerializeField] Choose GetData;
    int Mode = 1;
    int Difficult = 1;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Update()
    {
        try
        {
            Mode = GetData.GetModeselect();
        }
        catch
        {
      
        }
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
