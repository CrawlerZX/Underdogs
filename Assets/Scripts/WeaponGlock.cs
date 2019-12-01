using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGlock : MonoBehaviour
{
    public float damage = 10f;
    public float rpm = 15;
    public float range = 25f;
    public float magazine = 10f;
    private float secondsBetweenShoot;
    private float nextPossibleShoot;
    private Animator animator;
    public Transform spawnPoint;
    private LineRenderer tracer;

    void Start() 
    {
        secondsBetweenShoot = 60/rpm;

        if(GetComponent<LineRenderer>()) {
            tracer = GetComponent<LineRenderer>();
        }
    }

    void Update()
    {
        if (gameObject.activeSelf) {
        animator = GetComponentInParent<Animator>();
        animator.SetBool("UsingHandgun", true);
        animator.SetBool("UsingKnife", false);
        animator.SetBool("UsingSubmachine", false);

        }
        if (Input.GetAxis("Right Trigger") == 1) {
            Shoot();
        }

        if (Input.GetAxis("Left Trigger") == 1) {
            Reload();
        }
    }

    public void Shoot()
    {
        //animator.SetTrigger("Shoot");
        if (canShoot()) {
            Ray ray = new Ray(spawnPoint.position, spawnPoint.forward);
            RaycastHit hit;
            
            if (Physics.Raycast( ray, out hit, range)) {
                Debug.Log(hit.transform.name);

                EnemyBase target = hit.transform.GetComponent<EnemyBase>();
                if (target != null) {
                    target.TakeDamage(damage);
                }
            }

            nextPossibleShoot = Time.time + secondsBetweenShoot;

            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();

            if(tracer){
                StartCoroutine("RenderTracer", ray.direction * range);
            }
        }
    }

    void Reload()
    {
        animator.SetTrigger("Reload");
        magazine = 10f;
    }

    private bool canShoot()
    {
        bool canShoot = true;

        if (Time.time < nextPossibleShoot || magazine == 0) {
            canShoot = false;
        }

        return canShoot;
    }

    IEnumerator RenderTracer (Vector3 hitPoint){
        tracer.enabled = true;
        tracer.SetPosition(0, spawnPoint.position);
        tracer.SetPosition(1, spawnPoint.position + hitPoint);

        yield return null;
        tracer.enabled = false;
    }
}
