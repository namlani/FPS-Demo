using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takesDamage : MonoBehaviour, IDamageable {

	public float startingHealth;
	public float health;
	public bool dead;
	public CapsuleCollider col;
	enemyShoot shoot;

	AudioSource audioS;

	public Animator anim;


	protected virtual void Start() {
		health = startingHealth;
		shoot = GameObject.Find ("enemy").GetComponent<enemyShoot> ();
		audioS = GameObject.Find ("enemy").GetComponent<AudioSource> ();

	}
	public void TakeHit(float damage, RaycastHit hitInfo) {
		health -= damage;

		if (health <= 0 && dead == false) {
			Die ();
		}
	}

	protected void Die() {
		dead = true;
		audioS.Play ();
		col.enabled = false;
		anim.SetBool ("isDead", true);
		GameObject.Destroy(gameObject, 5f);
		Destroy (shoot);

	}
}
