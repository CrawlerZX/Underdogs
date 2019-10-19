using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool IsReady { get; set; }
    private EnemyConfiguration EnemyConfiguration { get; set; }

    public Transform Transform { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsReady)
        {
            if (Transform != null)
            {
                //Transform.Translate(new Vector3(Random.Range(90, 180), Random.Range(0, 90), Transform.position.z), Space.World);
            }            
        }        
    }

    public void LoadConfiguration(string enemyType)
    {
        EnemyConfiguration = EnemyFactory.GetConfiguration(enemyType);
        IsReady = true;
    }
}
