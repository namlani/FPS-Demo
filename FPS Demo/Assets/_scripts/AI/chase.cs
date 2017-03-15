using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chase : MonoBehaviour {

	public Transform player;
	public float moveSpeed;

	static Animator anim;

	public gun1 health;

	bool dead = false;

	gun1 takeDamage;

	public float moveDistance;

	public ParticleSystem electricity;


	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		takeDamage = GameObject.Find ("RigidBodyFPSController").GetComponent<gun1> ();

		health = GameObject.Find ("RigidBodyFPSController").GetComponent<gun1> ();

		electricity.enableEmission = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Vector3.Distance (player.position, this.transform.position) < moveDistance && dead == false) {

			electricity.enableEmission = true;


			Vector3 direction = player.position - this.transform.position;
			direction.y = 0; //stops reaction to height of player;

			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f); // slerp makes a slowlook at player

			anim.SetBool ("isIdle", false);
			if (direction.magnitude > 7f) { //mag is essentially length of the vector 
				this.transform.Translate (0, 0, moveSpeed); // z is forward axis in npc local space
				anim.SetBool ("isWalking", true);
				anim.SetBool ("isAttacking", false);
				anim.SetBool ("isDamaged", false);
				anim.SetBool ("isDead", false);




			}else {
				anim.SetBool ("isIdle", true);
				anim.SetBool ("isAttacking", false);
				anim.SetBool ("isWalking", false);
				anim.SetBool ("isDamaged", false);
				anim.SetBool ("isDead", false);




			}
		}

		else {
			anim.SetBool("isIdle", true);
			anim.SetBool("isWalking", false);
			anim.SetBool("isAttacking", false);
			anim.SetBool ("isDamaged", false);
			anim.SetBool ("isDead", false);





		}

/*		if (health.enemyHealth <= 0f) {
			anim.SetBool ("isDead", true);
			anim.SetBool("isWalking", false);
			anim.SetBool("isAttacking", false);
			anim.SetBool("isIdle", false);
			anim.SetBool ("isDamaged", false);

			dead = true;
			
			Destroy (gameObject, 5f);

		}
		/*
		if (takeDamage.enemyRecievingDamage == true) {

			anim.SetBool("isIdle", false);
			anim.SetBool("isWalking", false);
			anim.SetBool("isAttacking", false);
			anim.SetBool ("isDamaged", true);
			anim.SetBool ("isDead", false);

			takeDamage.enemyRecievingDamage = false;
		
		}*/
	}
}
