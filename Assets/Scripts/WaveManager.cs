using Newtonsoft.Json;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private Wave waveConfiguration;

    public void Start()
    {
        PlayerPrefs.DeleteKey(WaveSetup.KEY_CONFIGURATION);

        if (!PlayerPrefs.HasKey(WaveSetup.KEY_CONFIGURATION))
        {
            WaveSetup.setup();            
        }

        var waveSetupJson = PlayerPrefs.GetString(WaveSetup.KEY_CONFIGURATION);

        Debug.Log(waveSetupJson);

        //waveConfiguration = JsonConvert.DeserializeObject(waveSetupJson) as Wave;
        waveConfiguration = JsonConvert.DeserializeObject<Wave>(waveSetupJson, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
    }
}