using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour {

	AudioSource audioS;
	public float timer;
	public float startTime;
	bool triggerCheck;
	public GameObject player;
	public GameObject levelTwo;
	public GameObject gun;

	// Use this for initialization
	void Start () {
		
		audioS = GetComponent<AudioSource> ();
		triggerCheck = false;

		levelTwo.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0 && triggerCheck == true) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}

	}

	void OnTriggerEnter (Collider col) {
		timer = startTime;
		audioS.Play ();
		triggerCheck = true;
		levelTwo.SetActive (true);
		gun.SetActive (false);

		if (col.tag == "Player") {
		
			player.transform.position = new Vector3 (1000, 1000, 1000);
		}

	}
}
