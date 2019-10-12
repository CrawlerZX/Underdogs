using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectEffect : MonoBehaviour
{

    public Camera mainCamera;
    public Camera auxCamera;
    public Canvas canvas;
    public float clockEffect;
    public float clockAux = 0f;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera.enabled = true;
        auxCamera.enabled = false;   
    }

    // Update is called once per frame
    void Update()
    {
        clockEffect -= Time.deltaTime;
        Debug.Log(clockEffect);

        if(clockEffect <= 0.0){

            clockAux += Time.deltaTime;

            if(clockAux <= 1f){
                Debug.Log(clockAux);
                mainCamera.enabled = false;
                auxCamera.enabled = true;
                canvas.enabled = false;
                if(clockAux > 1f){
                    mainCamera.enabled = true;
                    auxCamera.enabled = false;
                }
            }
        } else{
            mainCamera.enabled = true;
            auxCamera.enabled = false;
            canvas.enabled = true;
        }
    }
        
}
