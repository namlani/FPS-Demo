using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forceDestruct : MonoBehaviour {

	public Transform player;
	Rigidbody rb;

	public float speed;
	public float force;

	bool stop;
	Vector3 direction;

	Vector3 playerPosition;

	AudioSource audioS;
	public AudioClip audioC;




	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player").transform;
		rb = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody> ();
		audioS = GetComponent<AudioSource> ();


		playerPosition = player.position;

		stop = false;
		direction = (transform.position - player.position).normalized;


	}
	
	// Update is called once per frame
	void Update () {
		
		float moveDistance = speed * Time.deltaTime;
		if (stop == false) {
			transform.position = Vector3.MoveTowards (transform.position, playerPosition, moveDistance);
		}
		if (transform.position == playerPosition) {
			stop = true;
		}
		if(stop == true){
			transform.position += -direction * moveDistance;

		}

		Destroy (gameObject, 5f);
	}

	void OnTriggerEnter(Collider col) {

		if (col.tag == "Player") {

			audioS.clip = audioC;
			audioS.Play ();

			rb.velocity = player.transform.forward * -force;

			Destroy (gameObject, .25f);
		}
	}
}

