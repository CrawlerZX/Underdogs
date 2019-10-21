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

    public abstract Material GetMaterial();
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

    public override Material GetMaterial()
    {
        return Resources.Load("Materials/EnemyRed") as Material;
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

    public override Material GetMaterial()
    {
        return Resources.Load("Materials/EnemyBlue") as Material;
    }
}
