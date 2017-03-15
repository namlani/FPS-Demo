using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnSpeed : MonoBehaviour {

	UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController controller;

	// Use this for initialization
	void Start () {

		controller = GameObject.Find ("RigidBodyFPSController").GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController> ();
	}

	void OnTriggerEnter (Collider col) {


			controller.movementSettings.ForwardSpeed = 0f;
			controller.movementSettings.CurrentTargetSpeed = 0f;
	}

	void OnTriggerExit (Collider col) {

		controller.movementSettings.ForwardSpeed = 6f;
		controller.movementSettings.CurrentTargetSpeed = 6f;
	}
}		

