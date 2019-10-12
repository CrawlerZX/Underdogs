using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour {

	[SerializeField] private Transform _head;
	private Animator _animator;
	public float MaxSpeed = 05;

	// Use this for initialization
	void Start () {
		
		_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (_animator == null) return;

		LookAt();

		var x = Input.GetAxis("Left Stick Horizontal");
		var y = Input.GetAxis("Left Stick Vertical");

		Move( x , y );

		if(Input.GetButtonDown("A Button")){
			_animator.SetBool("shooting", true);
		}

		if(Input.GetButtonUp("A Button")){
			_animator.SetBool("shooting", false);
		}
	}

	private void Move(float x, float y){

		_animator.SetFloat( "VelX" , x );
		_animator.SetFloat( "VelY" , y );

		transform.position += (Vector3.forward * MaxSpeed) * y * Time.deltaTime;
		transform.position += (Vector3.right * MaxSpeed) * x * Time.deltaTime; 

	}

	public void LookAt(){
		 Vector3 tp_moreClose = EnemyManager.GetMoreClose(_head.position);

		 transform.LookAt(tp_moreClose);
		//tp_moreClose.z = _head.position.z;

		//_head.right = (tp_moreClose - _head.position);
		//_head.eulerAngles = new Vector3(0f, 0f, _head.eulerAngles.z - 90f);
	}
}
