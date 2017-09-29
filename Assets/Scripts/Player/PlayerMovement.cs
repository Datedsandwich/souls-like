using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputController), typeof(StateManager))]
public class PlayerMovement : MonoBehaviour {
	public float speed = 5f;
	public float turnSpeed = 5f;
	public bool isMoving {
		get; private set;
	}
	public bool isGrounded {
		get; private set;
	}

	private Vector3 movement;
	private InputController inputController;
	private new Rigidbody rigidbody;
	private LayerMask ignoreLayers;

	void Awake() {
		inputController = GetComponent<InputController>();
		rigidbody = GetComponent<Rigidbody>();
		ignoreLayers = ~(1 << LayerMask.NameToLayer(GlobalLayers.damageColliders));
	}

	void FixedUpdate() {
		if (movement != Vector3.zero) {
			Quaternion targetRotation = Quaternion.LookRotation (movement.normalized);
			rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, targetRotation, Time.fixedDeltaTime * inputController.totalMovement * turnSpeed);
		}

		float horizontal = inputController.horizontal;
		float vertical = inputController.vertical;

		isMoving = inputController.totalMovement > 0.5;
		isGrounded = _IsGrounded();

		HandleMovement(horizontal, vertical);
	}

	public void HandleMovement(float horizontal, float vertical) {
		if(isGrounded) {
			Vector3 forwardMove = vertical * Vector3.Cross (Camera.main.transform.right, Vector3.up);
			Vector3 horizontalMove = horizontal * Camera.main.transform.right;

			movement = (forwardMove + horizontalMove).normalized;

			if(rigidbody.velocity.magnitude < speed) {
				movement *= speed - rigidbody.velocity.magnitude;
				rigidbody.AddForce(movement, ForceMode.Impulse);
			}
		}
	}

	private bool _IsGrounded() {
		float distanceToGround = 0.5f;
		Vector3 origin = transform.position	+ (Vector3.up * distanceToGround);

		Debug.DrawRay(origin, -Vector3.up, Color.black, distanceToGround + 0.1f);
		if(Physics.Raycast(origin, -Vector3.up, distanceToGround + 0.1f, ignoreLayers)) {
			return true;
		}

		return false;
	}
}
