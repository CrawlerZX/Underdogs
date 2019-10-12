using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{

    // Variaveis auxiliares
    public float rotationSpeed = 450f;
    public float walkSpeed = 1f;
    public float runSpeed = 2f;

    // Sistema
    public Joystick joystickLeft;
    //public Joystick joystickRight;
    private Quaternion targetRotation;

    public GameObject aim;

    // Componente
    private Animator anima;
    private CharacterController controller;
    public Gun gun;

    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = joystickLeft.Horizontal;
		var y = joystickLeft.Vertical;

        //var x = Input.GetAxis("Left Stick Horizontal");
		//var y = Input.GetAxis("Left Stick Vertical");

        if(Input.GetAxis("Left Trigger") == 1){
            gun.Recarga();
        }

        if(Input.GetButtonDown("LB Button")){
            anima.SetTrigger("Roll");
        }

        if(Input.GetButtonDown("RB Button")){
            anima.SetFloat( "VelY", y * 2f );
        }

        Move(x, y);
        Control();

        transform.LookAt(aim.transform.position);
    }

    void Control(){

        //Vector3 inputMove = new Vector3(Input.GetAxis("Left Stick Horizontal"),0,Input.GetAxis("Left Stick Vertical"));
        Vector3 inputMove = new Vector3(joystickLeft.Horizontal, 0, joystickLeft.Vertical);

        Vector3 motion = inputMove.normalized;
        //Vector3 motion = inputMove;
        motion *= (Input.GetButton("RB Button"))?runSpeed:walkSpeed;

        controller.Move(motion * Time.deltaTime);
    }

    void Move(float x, float y){

		anima.SetFloat( "VelX", x );
		anima.SetFloat( "VelY", y );

	}
}
