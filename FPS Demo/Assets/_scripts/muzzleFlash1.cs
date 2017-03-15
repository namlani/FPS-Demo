using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muzzleFlash1 : MonoBehaviour {

	public ParticleSystem mFlashLeft;
	public ParticleSystem mFlashRight;
	AudioSource audioG;
	public AudioClip mGun;

	void Start () {
		audioG = GetComponent<AudioSource> ();

	}
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			mFlashLeft.Play ();
			mFlashRight.Play ();


			if (audioG.isPlaying == false) {
				audioG.clip = mGun;
				audioG.Play ();
			}
		}
		if (Input.GetMouseButtonUp (0)) {
			mFlashLeft.Stop ();
			mFlashRight.Stop ();
			audioG.clip = mGun;
			audioG.Stop ();
		}

	}
}
