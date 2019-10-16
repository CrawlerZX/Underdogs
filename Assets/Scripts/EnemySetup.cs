public abstract class Enemy
{
    public abstract string name { get; set; }
}


[System.Serializable]
public class EnemySetup : Enemy
{
    public override string name { get; set; }

    public EnemySetup(string _name)
    {
        name = _name;
    }
}