using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public Wave waveConfiguration;

    public void Start()
    {
        if (!PlayerPrefs.HasKey("configuration") || !PlayerPrefs.HasKey("configurationEnemys"))
        {
            //Debug.Log("setup");
            WaveSetup.setup();
        }

        var waveSetupJson = PlayerPrefs.GetString("configuration");
        waveConfiguration = JsonUtility.FromJson<Wave>(waveSetupJson);

        var enemyListJson = PlayerPrefs.GetString("configutrationEnemys");
        List<EnemySetup> enemyList = JsonUtility.FromJson<List<EnemySetup>>(enemyListJson);

        waveConfiguration.enemyList = enemyList;

        //Debug.Log(enemyListJson);

        //Debug.Log(waveConfiguration.enemyList[0].name);
    }

}