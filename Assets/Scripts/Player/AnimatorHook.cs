using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorHook : MonoBehaviour {
	private Animator animator;
	private new Rigidbody rigidbody;
	private StateManager stateManager;

	public void Init(StateManager stateManager, Rigidbody rigidbody) {
		animator = GetComponent<Animator>();
		this.rigidbody = rigidbody;
		this.stateManager = stateManager;
	}
	
	void OnAnimatorMove () {
		if(!stateManager.isApplyingRootMotion) {
			return;
		}

		float multiplier = 5;

		Vector3 delta = animator.deltaPosition;

		rigidbody.AddForce(delta * multiplier, ForceMode.VelocityChange);
	}

	void LateUpdate() {

	}
}
