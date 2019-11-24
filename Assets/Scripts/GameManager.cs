using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public WaveManager WaveManager { get; set; }

    public Text WaveTimer { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        WaveManager = GameObject.FindObjectOfType<WaveManager>();
        var tmp = GameObject.FindWithTag("WaveTimer"); 

        if (tmp != null)
        {
            WaveTimer = tmp.GetComponent<Text>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (WaveManager != null && WaveTimer != null)
        {
            if (WaveManager.IsTimer())
            {
                var time = WaveManager.GetWaveTimer();

                if (time > 0)
                {
                    WaveTimer.text = time.ToString("00");
                }
            }
            else
            {
                WaveTimer.text = "00";
            }            
        }        
    }
}
