using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float speed;

	private Vector3 movement;
	private new Rigidbody rigidbody;

	void Awake() {
		rigidbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
		if (movement != Vector3.zero) {
			rigidbody.transform.rotation = Quaternion.LookRotation (movement);
		}
	}

	public void HandleMovement(float horizontal, float vertical) {
		rigidbody.drag = Mathf.Abs(horizontal) + Mathf.Abs(vertical) > 0.5 ? 0 : 4;

		Vector3 forwardMove = vertical * Vector3.Cross (Camera.main.transform.right, Vector3.up);
		Vector3 horizontalMove = horizontal * Camera.main.transform.right;

		movement = (forwardMove + horizontalMove).normalized;

		movement = movement.normalized * speed * Time.deltaTime;
		rigidbody.MovePosition (transform.position + movement);
	}
}
