using Newtonsoft.Json;
using UnityEngine;
public class WaveManager : MonoBehaviour
{
    private Transform ParentTransform { get; set; }

    private WaveConfiguration waveConfiguration;

    public void Start()
    {
        PlayerPrefs.DeleteKey(WaveSetup.KEY_CONFIGURATION);

        if (!PlayerPrefs.HasKey(WaveSetup.KEY_CONFIGURATION))
        {
            WaveSetup.setup();
        }

        var waveSetupJson = PlayerPrefs.GetString(WaveSetup.KEY_CONFIGURATION);
        waveConfiguration = JsonConvert.DeserializeObject<WaveConfiguration>(waveSetupJson, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

        ParentTransform = GetComponent<Transform>();

        if (waveConfiguration != null)
        {
            Object prefab = Resources.Load("Prefab/EnemyPrefab");

            if (prefab != null)
            {
                for (int i = 0; i < waveConfiguration.enemyTypesList.Length - 1; i++)
                {
                    var enemyType = waveConfiguration.enemyTypesList[i];

                    if (string.IsNullOrEmpty(enemyType))
                        continue;

                    GameObject newObject = Instantiate(prefab, ParentTransform) as GameObject;
                    Enemy enemyScript = newObject.GetComponent<Enemy>();

                    if (enemyScript != null)
                    {   
                        enemyScript.LoadConfiguration(enemyType);
                    }
                }
            }            
        }
    }
}