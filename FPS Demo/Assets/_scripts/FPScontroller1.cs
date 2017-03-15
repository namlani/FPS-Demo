using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class FPScontroller1 : MonoBehaviour {

	public float initialMovementSpeed = 5.0f;
	public float movementSpeed = 0;
	public float mouseSensitivity = 2.0f;
	public float jumpSpeed = 5f;
	public float runSpeed = 6;

	float rawY = 0;
	public float xRange = 60.0f;

	float verticalVelocity = 0;

	CharacterController characterController;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		characterController = GetComponent<CharacterController> ();

	}
	
	// Update is called once per frame
	void Update () {

		//rotation

		float rawX = Input.GetAxis ("Mouse X") * mouseSensitivity;
		transform.Rotate (0, rawX, 0);

		rawY -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		rawY = Mathf.Clamp (rawY, -xRange, xRange);
		Camera.main.transform.localRotation = Quaternion.Euler (rawY, 0, 0);

		//movement

		float forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed;
		float sideSpeed = Input.GetAxis ("Horizontal") * movementSpeed;

		verticalVelocity += Physics.gravity.y * Time.deltaTime; //downward acceleration

		if (characterController.isGrounded && Input.GetButtonDown ("Jump")) {
			verticalVelocity = jumpSpeed;
		} //stops infinite jumping 

		Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);

		speed = transform.rotation * speed;

		characterController.Move(speed * Time.deltaTime);

		bool running = Input.GetKey (KeyCode.LeftShift);
		if (running == true) {
			movementSpeed = runSpeed;
		}
		if (running == false) {
			movementSpeed = initialMovementSpeed;
		}
	}
}
