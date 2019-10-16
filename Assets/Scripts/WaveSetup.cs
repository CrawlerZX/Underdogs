using Newtonsoft.Json;
using UnityEngine;

public class WaveSetup
{
    public const string KEY_CONFIGURATION = "configuration";

    public static void setup()
    {
        if (!PlayerPrefs.HasKey(WaveSetup.KEY_CONFIGURATION))
        {
            var wave = new Wave();
            wave.size = 10;            
            wave.hasBoss = false;
            wave.hasTime = false;

            var EnemySetup01 = new EnemySetup("knife");
            //EnemySetup01.name = "knife";
            var EnemySetup02 = new EnemySetup("grenade");
            ////EnemySetup02.name = "grenade";
            //var EnemySetup03 = new EnemySetup();
            //EnemySetup03.name = "assaultRifle";
            //var EnemySetup04 = new EnemySetup();
            //EnemySetup04.name = "sniper";
            //var EnemySetup05 = new EnemySetup();
            //EnemySetup05.name = "knife";
            //var EnemySetup06 = new EnemySetup();
            //EnemySetup06.name = "shotgun";
            //var EnemySetup07 = new EnemySetup();
            //EnemySetup07.name = "speedKnife";
            //var EnemySetup08 = new EnemySetup();
            //EnemySetup08.name = "molotov";
            //var EnemySetup09 = new EnemySetup();
            //EnemySetup09.name = "bazuka";
            //var EnemySetup10 = new EnemySetup();
            //EnemySetup10.name = "assaultRifle";

            //var enemyList = new List<EnemySetup>();
            wave.enemyList.Add(EnemySetup01);
            wave.enemyList.Add(EnemySetup02);
            //wave.enemyList.Add(EnemySetup03);
            //wave.enemyList.Add(EnemySetup04);
            //wave.enemyList.Add(EnemySetup05);
            //wave.enemyList.Add(EnemySetup06);
            //wave.enemyList.Add(EnemySetup07);
            //wave.enemyList.Add(EnemySetup08);
            //wave.enemyList.Add(EnemySetup09);
            //wave.enemyList.Add(EnemySetup10);

            var setting = new JsonSerializerSettings();
            setting.Formatting = Formatting.Indented;
            setting.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            setting.TypeNameHandling = TypeNameHandling.All;

            var json = JsonConvert.SerializeObject(wave, setting);

            Debug.Log(json);

            PlayerPrefs.SetString(WaveSetup.KEY_CONFIGURATION, json);
        }
    }
}