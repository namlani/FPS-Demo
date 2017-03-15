using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun1 : MonoBehaviour {

	public float range = 100;
	public float fireRate = 0.2f;
	public float damage = 1;
	float cooldownRemaining = 0;

	public GameObject bullet;

	public LayerMask collisionMask;

	bool colorChange = false;
	public Material mat;

	void Start () {

	}

	void Update () {
		CheckCollisions (range);
		CheckColorChange ();
	}

	void CheckCollisions(float range) {
		cooldownRemaining -= Time.deltaTime;

		if (Input.GetMouseButton(0) && cooldownRemaining <= 0) {
			Ray ray = new Ray (Camera.main.transform.position + Camera.main.transform.forward*0.5f, Camera.main.transform.forward); //foward*float so player doesn't shoot self when moving backward
			RaycastHit hitInfo;
			cooldownRemaining = fireRate;

			if (Physics.Raycast (ray, out hitInfo, range, collisionMask, QueryTriggerInteraction.Collide)) {
				Vector3 hitPoint = hitInfo.point;
				OnHitObject (hitInfo);
				Instantiate (bullet, hitPoint, Quaternion.LookRotation( hitInfo.normal) );
			}


		}
	}

	void CheckColorChange() {

		if (colorChange == true) {

			mat.SetColor ("_EmissionColor", Color.red);
			colorChange = false;
		} else {
			mat.SetColor ("_EmissionColor", Color.green);

		}
	}

	void OnHitObject(RaycastHit hitInfo) {
		IDamageable damageableObject = hitInfo.collider.GetComponent<IDamageable> ();

		if (damageableObject != null) {
			damageableObject.TakeHit (damage, hitInfo);
			colorChange = true;

		}
	}
}
