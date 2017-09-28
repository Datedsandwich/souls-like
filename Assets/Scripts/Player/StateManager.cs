using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {
	public float horizontal;
	public float vertical;

	public bool isLockedOn;

	public GameObject activeModel;
	private Animator animator;

	void Start() {
		if(activeModel == null) {
			Debug.LogError("No active model assigned to the StateManager!");
		}

		animator = activeModel.GetComponent<Animator>();		

		animator.applyRootMotion = false;
	}

	public void FixedTick(float absoluteMovement) {
		if(!isLockedOn) {
			animator.SetFloat("Vertical", absoluteMovement);
		} else {
			animator.SetFloat("Horizontal", horizontal);
			animator.SetFloat("Vertical", vertical);
		}
	}
}
