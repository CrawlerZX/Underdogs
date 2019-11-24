using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool IsReady { get; set; }

    private EnemyConfiguration EnemyConfiguration { get; set; }

    private Transform Transform { get; set; }

    private MeshRenderer MeshRenderer { get; set; }

    // Start is called before the first frame update
    void Awake()
    {
        Transform = GetComponent<Transform>();
        MeshRenderer = GameObject.Find("CubeEnemy").GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        IsReady = true;
        if (IsReady)
        {
            if (Transform != null)
            {
                
            }            
        }        
    }

    public void LoadConfiguration(string enemyType)
    {
        EnemyConfiguration = EnemyFactory.GetConfiguration(enemyType);

        if (MeshRenderer != null)
        {
            var mat = EnemyConfiguration.GetMaterial();

            if (mat != null)
            {
                MeshRenderer.material = mat;
                Debug.Log("Material Set");
            }
            else
            {
                Debug.Log("Material = null");
            }
        }
        else
        {
            Debug.Log("MeshRenderer = null");
        }

        IsReady = true;
    }
}
