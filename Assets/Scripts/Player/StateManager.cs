using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputController))]
public class StateManager : MonoBehaviour {
	public bool isLockedOn;
	public bool isApplyingRootMotion;

	public GameObject activeModel;
	private Animator animator;
	private AnimatorHook animatorHook;
	private InputController inputController;

	void Start() {
		if(activeModel == null) {
			Debug.LogError("No active model assigned to the StateManager!");
		}

		animator = activeModel.GetComponent<Animator>();
		inputController = GetComponent<InputController>();

		animatorHook = activeModel.AddComponent<AnimatorHook>();
		animatorHook.Init(this, GetComponent<Rigidbody>());

		animator.applyRootMotion = false;
	}

	void FixedUpdate() {
		HandleMovementAnimations();

		isApplyingRootMotion = animator.GetBool("ApplyRootMotion");

		animator.applyRootMotion = isApplyingRootMotion;

		if(!isApplyingRootMotion) {
			animator.SetBool("IsBlocking", inputController.block);
		}

		HandleUninterruptibleAnimations();
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

		animator.SetBool("IsSprinting", inputController.isSprinting);

		if(inputController.isSprinting) {
			isLockedOn = false;
		}
	}

	private void HandleUninterruptibleAnimations() {
		HandleCombatAnimations();
	}
	private void HandleCombatAnimations() {
		if(isApplyingRootMotion) {
			animator.SetBool("IsBlocking", false);
			return;
		}

		string targetAnimation = "";

		if(inputController.lightAttack) {
			targetAnimation = "oh_attack_1";
		} else if (inputController.heavyAttack) {
			targetAnimation = "oh_attack_3";
		} else if (inputController.parry) {
			targetAnimation = "parry";
		}

		if(!string.IsNullOrEmpty(targetAnimation)) {
			animator.Play(targetAnimation);
		}
	}
}
