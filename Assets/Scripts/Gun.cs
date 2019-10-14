using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Gun : MonoBehaviour
{
    public float tpm;

    public float damage = 10f;

    public float range = 100f;
    public Transform spawn;
    private Animator animator;
    public Transform target;
    public float pente = 10f;

    private LineRenderer tracer;

    //Sistema
    private float segundosEntreDisparos;
    private float proxPossivelDisparo;

    void Start() 
    {
        animator = GetComponentInParent<Animator>();
        segundosEntreDisparos = 60/tpm;

        if(GetComponent<LineRenderer>()) {
            tracer = GetComponent<LineRenderer>();
        }
    }

    public void Disparar(){

        if(podeDisparar()){
            transform.LookAt(target);

            Ray ray = new Ray(spawn.position, spawn.forward);
            RaycastHit hit;

            pente -= 1;

            float distanciaTiro = 250f;
            
            if(Physics.Raycast(ray, out hit, distanciaTiro)){
            distanciaTiro = hit.distance;
            }

            proxPossivelDisparo = Time.time + segundosEntreDisparos;

            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();

            if(tracer){
                StartCoroutine("RenderTracer", ray.direction * distanciaTiro);
            }

            animator.SetTrigger("Shoot");
        }

    }

    public void Recarga()
    {
        animator.SetTrigger("Reload");
        pente = 10f;
    }

    private bool podeDisparar()
    {
        bool podeDisparar = true;

        if (Time.time < proxPossivelDisparo || pente == 0) {
            podeDisparar = false;
        }

        return podeDisparar;
    }

    IEnumerator RenderTracer (Vector3 hitPoint){
        tracer.enabled = true;
        tracer.SetPosition(0, spawn.position);
        tracer.SetPosition(1, spawn.position + hitPoint);

        yield return null;
        tracer.enabled = false;
    }
}
