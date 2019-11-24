using Newtonsoft.Json;
using UnityEngine;

public class WaveSetup
{
    public const string KEY_CONFIGURATION = "configuration";

    public static void setup()
    {
        if (!PlayerPrefs.HasKey(WaveSetup.KEY_CONFIGURATION))
        {
            var wave = new WaveConfiguration(2);
            wave.hasBoss = false;
            wave.bossAtEnd = false;
            wave.bossType = "";
            wave.hasTime = true;
            wave.time = 100;

            wave.enemyTypesList[0] = "knife";
            wave.enemyTypesList[1] = "grenade";
            //wave.enemyTypesList[2] = "knife";
            //wave.enemyTypesList[3] = "grenade";
            //wave.enemyTypesList[4] = "knife";
            //wave.enemyTypesList[5] = "grenade";
            //wave.enemyTypesList[6] = "knife";
            //wave.enemyTypesList[7] = "grenade";
            //wave.enemyTypesList[8] = "knife";
            //wave.enemyTypesList[9] = "grenade";

            var setting = new JsonSerializerSettings();
            setting.Formatting = Formatting.Indented;

            var json = JsonConvert.SerializeObject(wave, setting);

            PlayerPrefs.SetString(WaveSetup.KEY_CONFIGURATION, json);
        }
    }
}