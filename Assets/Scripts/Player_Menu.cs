using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Menu : MonoBehaviour
{
    private Animator anima;
    [Range(0,20)]
    public float clock = 15f ;
    private bool NextIdleI = true;
    private bool NextIdleII = false;
    private float rotSpeed = 5;

    void Start()
    {
        anima = GetComponent<Animator>();

        Vector3 charStart = new Vector3(0,0,-7.5f);
        transform.SetPositionAndRotation(charStart,Quaternion.Euler(0,0,0));
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z <= -1.5f){
            anima.SetBool("WalkingMenu", true);

            transform.position += Vector3.forward * Time.deltaTime;


        } else{
            anima.SetBool("WalkingMenu",false);

            float rotY = Input.GetAxis("Mouse X") * rotSpeed;

            transform.Rotate(Vector3.up, rotY);
            //transform.Rotate(Vector3.up, Time.deltaTime * 5f);
        }

        clock -= Time.deltaTime;

        if(clock <= 0.0){
            if(NextIdleI){
            anima.SetBool("Idle Break I", true);
            }
            clock = 35f;
        }
        
    }

    public void IdleBreakIEvent(){
        NextIdleII = false;
        anima.SetBool("Idle Break I", false);
    }
}
