﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [RequireComponent(typeof(CharacterController))]

public class PlayerController_v2 : MonoBehaviour
{
    [SerializeField] private Transform _head;
    [Range(1,10)]
    public float walkSpeed = 5f;
    public float runSpeed = 8f;
    public float rotationSpeed = 450f;
    public Joystick joystick;
    private Animator anima;
    private float knifeRange = 1.75f;
    private CharacterController controller;
    private Gun gun;
    private Quaternion targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        gun = GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        Control();

        if( Input.GetKey(KeyCode.Space)){
            gun.Disparar();
        }
    }

    void Control(){

        var inputX = joystick.Horizontal;
        var inputY = joystick.Vertical;

        Vector3 inputMove = new Vector3(joystick.Horizontal, 0, joystick.Vertical);

        if(inputMove != Vector3.zero){
            targetRotation = Quaternion.LookRotation(inputMove);
            transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y,targetRotation.eulerAngles.y,rotationSpeed * Time.deltaTime);
        }

        Vector3 motion = inputMove.normalized;
        //Vector3 motion = inputMove;
        motion = motion * walkSpeed;

        controller.Move(motion * Time.deltaTime);

        if(inputX != 0.0 || inputY != 0.0 ){
            anima.SetBool("isRunning", true);
        } else{
            anima.SetBool("isRunning", false);
        }
    }
    /*
    	public void LookAt(){
		Vector3 tp_moreClose = EnemyManager.GetMoreClose(_head.position);

		 transform.LookAt(tp_moreClose);
		//tp_moreClose.z = _head.position.z;

		//_head.right = (tp_moreClose - _head.position);
		//_head.eulerAngles = new Vector3(0f, 0f, _head.eulerAngles.z - 90f);
	}
    */

    public void KnifeAttack(){
        anima.SetTrigger("KnifeAttack");
    }
    
}