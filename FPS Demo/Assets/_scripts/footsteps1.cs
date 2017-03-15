using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps1 : MonoBehaviour {

	UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController controller;
	Rigidbody cc;
	AudioSource audioS;
	public AudioClip walk;
	public AudioClip run;

	void Start ()
	{
		cc = GameObject.Find("RigidBodyFPSController").GetComponent<Rigidbody> ();
		controller = GameObject.Find ("RigidBodyFPSController").GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController> ();

		audioS = GetComponent<AudioSource> ();

	}

void Update ()
{
		if (controller.Grounded == true && cc.velocity.magnitude > 4f && cc.velocity.magnitude < 9f && audioS.isPlaying == false)
		{
		audioS.volume = Random.Range(0.6f, 0.7f); 
		audioS.pitch = Random.Range(0.7f, 1f);
		audioS.clip = walk;
			audioS.Play ();

	}
		if (controller.Grounded == true && cc.velocity.magnitude >= 11f && audioS.isPlaying == false)
		{
			audioS.volume = Random.Range(0.6f, 0.7f); 
			audioS.pitch = Random.Range(0.7f, 1f);
			audioS.clip = run;
			audioS.Play ();
		}

	}
}﻿
