using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestruct1 : MonoBehaviour {

	public float duration = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		duration -= Time.deltaTime;
		if (duration <= 0) {
			Destroy (gameObject);
		}
	}
}
