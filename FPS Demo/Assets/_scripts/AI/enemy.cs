using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : takesDamage {

	public enum State {Idle, Chasing, Attacking};

	State currentState;
	NavMeshAgent pathfinder;
	Transform target;


	public float moveDistance;


	protected override void Start () { //override here and virtual in takeDamage so can call both class; start methods on enemy
		base.Start(); //starts takesDamage start method
		pathfinder = GameObject.Find("enemy").GetComponent<NavMeshAgent>();


		currentState = State.Idle;
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update () {
		if (Vector3.Distance (target.position, this.transform.position) <= moveDistance) {
			StartCoroutine (UpdatePath ());
		}

	}

	IEnumerator UpdatePath() { //repeat this loop every n seconds, so as to not refresh enemy reaction every frame to save performance
		float refreshRateofPath = 0.25f;
		currentState = State.Chasing;
		while(target != null){
			if (currentState == State.Chasing) {
				Vector3 targetPosition = new Vector3 (target.position.x, target.position.y, target.position.z); // make sure on ground

					if (dead == false) {
						pathfinder.SetDestination (targetPosition);
					} else {
						pathfinder.enabled = false;
					}
				}
			yield return new WaitForSeconds (refreshRateofPath);

			anim.SetBool ("isIdle", false);
			}
		}

	 


}
