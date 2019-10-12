using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{    
    public int size;
    public List<EnemySetup> enemyList;
    public bool hasTime;
    public float time;
    public bool hasBoss;
    public EnemySetup boss;
    public bool atEnd;

    public Wave()
    {
        enemyList = new List<EnemySetup>();
    }

}
