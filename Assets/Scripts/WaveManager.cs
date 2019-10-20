using Newtonsoft.Json;
using UnityEngine;
public class WaveManager : MonoBehaviour
{
    private float WaveTimer { get; set; }

    private Transform ParentTransform { get; set; }

    private WaveConfiguration waveConfiguration { get; set; }

    public void Start()
    {
        PlayerPrefs.DeleteKey(WaveSetup.KEY_CONFIGURATION);

        if (!PlayerPrefs.HasKey(WaveSetup.KEY_CONFIGURATION))
        {
            WaveSetup.setup();
        }

        var waveSetupJson = PlayerPrefs.GetString(WaveSetup.KEY_CONFIGURATION);

        waveConfiguration = JsonConvert.DeserializeObject<WaveConfiguration>(waveSetupJson, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

        SpawnEnemys();
        SetTime();
    }

    private void Update()
    {
        if (WaveTimer > 0)
        {
            WaveTimer -= Time.deltaTime;
        }
    }

    private void SetTime()
    {
        if (waveConfiguration.hasTime)
        {
            WaveTimer = waveConfiguration.time;
        }        
    }

    private void SpawnEnemys()
    {
        ParentTransform = GameObject.FindWithTag("RespawnArea").transform;

        Object prefab = Resources.Load("Prefab/EnemyPrefab");

        if (waveConfiguration != null && ParentTransform != null && prefab != null)
        {
            for (int i = 0; i <= waveConfiguration.enemyTypesList.Length - 1; i++)
            {
                var enemyType = waveConfiguration.enemyTypesList[i];

                if (string.IsNullOrEmpty(enemyType))
                    continue;

                GameObject newObject = Instantiate(prefab, new Vector3(Random.Range(0, ParentTransform.position.x), ParentTransform.position.y, ParentTransform.position.z), Quaternion.identity) as GameObject;

                Enemy enemyScript = newObject.GetComponent<Enemy>();

                if (enemyScript != null)
                {
                    enemyScript.LoadConfiguration(enemyType);
                }
            }
        }
    }

    public float GetWaveTimer()
    {
        return WaveTimer;
    }

    public bool IsTimer()
    {
        return waveConfiguration.hasTime;
    }

}