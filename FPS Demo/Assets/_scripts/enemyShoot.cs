using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour {

	public GameObject enemy;
	public Transform enemyLocale;
	public Transform player;
	enemy enemyScript;
	public GameObject projectile;
	public GameObject projectileClone;
	public GameObject projectileCloneT;

	bool hasShot;
	public float distance;
	public float attackDelay;
	public float attackStartTime;


	// Use this for initialization
	void Start () {

		enemyScript = enemy.GetComponent<enemy> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		enemyLocale = GameObject.Find("enemy").transform;

		hasShot = false;
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 startSpot = new Vector3 (enemyLocale.position.x, enemyLocale.position.y + 2, enemyLocale.position.z);

		attackDelay = attackDelay -= Time.deltaTime;

		if (hasShot == false && Vector3.Distance (player.position, this.transform.position) <= distance) {
			projectileClone = (GameObject)GameObject.Instantiate (projectile, startSpot, Quaternion.identity);

			hasShot = true;
		}

		if (hasShot == true & attackDelay <= 0) {

			attackDelay = attackStartTime;
			hasShot = false;
		}

	}
}
