using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSetup
{
    public static void setup()
    {
        if (!PlayerPrefs.HasKey("configuration") || !PlayerPrefs.HasKey("configutrationEnemys"))
        {
            var wave = new Wave();
            wave.size = 10;            
            wave.hasBoss = false;
            wave.hasTime = false;

            string json = JsonUtility.ToJson(wave);

            PlayerPrefs.SetString("configuration", json);

            var EnemySetup01 = new EnemySetup();
            EnemySetup01.name = "knife";
            var EnemySetup02 = new EnemySetup();
            EnemySetup02.name = "grenade";
            var EnemySetup03 = new EnemySetup();
            EnemySetup03.name = "assaultRifle";
            var EnemySetup04 = new EnemySetup();
            EnemySetup04.name = "sniper";
            var EnemySetup05 = new EnemySetup();
            EnemySetup05.name = "knife";
            var EnemySetup06 = new EnemySetup();
            EnemySetup06.name = "shotgun";
            var EnemySetup07 = new EnemySetup();
            EnemySetup07.name = "speedKnife";
            var EnemySetup08 = new EnemySetup();
            EnemySetup08.name = "molotov";
            var EnemySetup09 = new EnemySetup();
            EnemySetup09.name = "bazuka";
            var EnemySetup10 = new EnemySetup();
            EnemySetup10.name = "assaultRifle";

            var enemyList = new List<EnemySetup>();
            enemyList.Add(EnemySetup01);
            enemyList.Add(EnemySetup02);
            enemyList.Add(EnemySetup03);
            enemyList.Add(EnemySetup04);
            enemyList.Add(EnemySetup05);
            enemyList.Add(EnemySetup06);
            enemyList.Add(EnemySetup07);
            enemyList.Add(EnemySetup08);
            enemyList.Add(EnemySetup09);
            enemyList.Add(EnemySetup10);

            var listJson = JsonUtility.ToJson(enemyList);
            Debug.Log(listJson);
            PlayerPrefs.SetString("configutrationEnemys", listJson);
        }
    }
}