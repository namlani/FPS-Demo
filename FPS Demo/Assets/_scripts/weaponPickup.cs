using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponPickup : MonoBehaviour {

	public GameObject scriptObject;
	public GameObject kGun;
	GameObject kGunItem;
	public Renderer rend;

	public GameObject xhair;

	AudioSource audioS;
	public AudioClip pickupSound;


	// Use this for initialization
	void Start () {

		scriptObject.GetComponent<gun1> ().enabled = false;
		kGun = GameObject.FindWithTag ("gun");
		rend = GetComponent<Renderer> ();

		xhair = GameObject.FindWithTag ("xhair");

		audioS = GetComponent<AudioSource> ();

		kGun.SetActive (false);
		xhair.SetActive (false);
	}
	
	void OnTriggerEnter (Collider col) {

		if (col.tag == "Player") {

			scriptObject.GetComponent<gun1> ().enabled = true;
			kGun.SetActive (true);
			xhair.SetActive (true);

			audioS.clip = pickupSound;
			audioS.Play ();

			rend.enabled = false;
			Destroy (gameObject, 0.4f);
		}
	}
}
