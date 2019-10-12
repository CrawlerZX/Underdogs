using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float health = 50f;
    private Transform player;
    private Transform enemy;
    private float MoveSpeed = 4f;
    private float MaxDist = 10;
    private float MinDist = 5;
    private Animator enemyAnim;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyAnim = GetComponent<Animator>();
    }
    

    void Update(){
        transform.LookAt(player);

        if(Vector3.Distance(transform.position,player.position) >= MinDist){
            
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        
            enemyAnim.SetBool("EnemyRunning", true);
            enemyAnim.SetBool("EnemyShooting", false);
                
            if(Vector3.Distance(transform.position, player.position) <= MaxDist){
                enemyAnim.SetBool("EnemyShooting", true);
            }
        
        }
        
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        
        if(health <= 0f){
            Die();
        }

    }

    void Die()
    {
        Destroy(gameObject);
    }
}
