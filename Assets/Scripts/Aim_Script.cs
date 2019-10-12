using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim_Script : MonoBehaviour {
	 public Transform Target;
	 public Vector3 Offset;

	 Animator anima;
	 Transform chest;


	// Use this for initialization
	void Start () {
		
		anima = GetComponent<Animator>();
		chest = anima.GetBoneTransform(HumanBodyBones.Chest);
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		
		chest.LookAt(Target.position);
		chest.rotation = chest.rotation * Quaternion.Euler(Offset); 

	}
}
