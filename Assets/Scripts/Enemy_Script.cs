using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
    public int myIndex{get; set;}

    // Start is called before the first frame update
    private void Start()
    {
        EnemyManager.enemy.Add(this);
        myIndex = EnemyManager.enemy.Count - 1;
        
    }

    private void OnDestroy()
    {
        EnemyManager.enemy.RemoveAt(myIndex);
        EnemyManager.SubtractIndex(myIndex);
        
    }
}
