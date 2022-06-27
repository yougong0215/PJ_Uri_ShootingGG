using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class WaitFor : MonoBehaviour
{
    [SerializeField] Image Panel;
    [SerializeField] TextMeshProUGUI Again;
    [SerializeField] TextMeshProUGUI Stop;
    SceneData _SC;
    int AgainStop = 1;
    void Start()
    {
        _SC = GameObject.Find("StartData").GetComponent<SceneData>();
        Panel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Panel.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        if (Panel.gameObject.activeSelf == true)
        {
            if (AgainStop == 1)
            {
                Again.color = new Color(255, 0, 0);
                Stop.color = new Color(255, 255, 255);
                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    AgainStop = 2;
                }
                if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return))
                {
                    Time.timeScale = 1;
                    Panel.gameObject.SetActive(false);
                }
            }
            if (AgainStop == 2)
            {
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    AgainStop = 1;
                }
                Again.color = new Color(255, 255, 255);
                Stop.color = new Color(255, 0, 0);
                if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return))
                {
                    Destroy(_SC.gameObject);
                    SceneManager.LoadScene("Start");
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
}
