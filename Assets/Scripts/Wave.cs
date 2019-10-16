using System;
using System.Collections.Generic;

[Serializable]
public class Wave
{   
    public int size;

    public List<Enemy> enemyList;

    public bool hasTime;

    public float time;

    public bool hasBoss;

    public EnemySetup boss;

    public bool bossAtEnd;

    public Wave()
    {
        enemyList = new List<Enemy>();
    }
}
