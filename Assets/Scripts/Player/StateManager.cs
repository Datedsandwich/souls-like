﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputController))]
public class StateManager : MonoBehaviour {
	public bool isLockedOn;

	public GameObject activeModel;
	private Animator animator;
	private InputController inputController;

	void Start() {
		if(activeModel == null) {
			Debug.LogError("No active model assigned to the StateManager!");
		}

		animator = activeModel.GetComponent<Animator>();
		inputController = GetComponent<InputController>();

		animator.applyRootMotion = false;
	}

	void FixedUpdate() {
		HandleMovementAnimations();

		if(inputController.isSprinting) {
			isLockedOn = false;
		}
	}

	public void setGrounded(bool isGrounded) {
		animator.SetBool("IsGrounded", isGrounded);
	}

	private void HandleMovementAnimations() {
		if(!isLockedOn) {
			animator.SetFloat("Vertical", inputController.totalMovement, 0.4f, Time.fixedDeltaTime);
		} else {
			animator.SetFloat("Horizontal", inputController.horizontal);
			animator.SetFloat("Vertical", inputController.vertical);
		}

		animator.SetBool("isSprinting", inputController.isSprinting);
	}
}
