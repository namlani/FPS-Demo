using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncepad : MonoBehaviour {

	UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController controller;
	Rigidbody rb;
	AudioSource audioS;

	public AudioClip swoosh;
	public float thrust;
	public float x;
	public float y;
	public float z;
	// Use this for initialization
	void Start () {

		controller = GameObject.Find ("RigidBodyFPSController").GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController> ();
		rb = GameObject.Find ("RigidBodyFPSController").GetComponent<Rigidbody>();
		audioS = GetComponent<AudioSource> ();

	}
	
	void OnTriggerEnter (Collider col) {
		
		if (tag == "jpad") {

			controller.advancedSettings.stickToGroundHelperDistance = 0f;
			rb.AddForce (new Vector3 (x, y, z) * thrust);
			audioS.clip = swoosh;
			audioS.Play ();
		}
	}

	void OnTriggerExit (Collider col) {
		controller.advancedSettings.stickToGroundHelperDistance = 1f;

	}
}		
