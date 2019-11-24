using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveConfiguration
{
    private int size;

    public string[] enemyTypesList;

    public bool hasTime;

    public float time;

    public bool hasBoss;

    public string bossType;

    public bool bossAtEnd;

    public WaveConfiguration(int size)
    {
        enemyTypesList = new string[size];
    }
}
