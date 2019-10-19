using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory 
{
    public static EnemyConfiguration GetConfiguration(string enemyType)
    {
        switch (enemyType.ToLower().Trim())
        {
            case "knife": return new EnemyKnife(enemyType);
            case "grenade": return new EnemyGranade(enemyType);
            default:
                return null;
        }
    }
}

public abstract class EnemyConfiguration
{
    private string type { get; set; }

    public EnemyConfiguration(string type) {  }

    public abstract void Walk();
}

public class EnemyKnife : EnemyConfiguration
{
    public EnemyKnife(string type) : base (type)
    {
        
    }

    public override void Walk()
    {
        Debug.Log("EnemyKnife walking!");
    }
}

public class EnemyGranade : EnemyConfiguration
{
    public EnemyGranade(string type) : base(type)
    {
        
    }

    public override void Walk()
    {
        Debug.Log("EnemyGranade walking!");
    }
}
