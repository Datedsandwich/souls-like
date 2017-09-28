using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(StateManager))]
public class InputController : MonoBehaviour {
	private PlayerMovement playerMovement;
	private StateManager stateManager;
	
	private float horizontal;
	private float vertical;
	private float absoluteMovement;

	void Start () {
		playerMovement = GetComponent<PlayerMovement>();
		stateManager = GetComponent<StateManager>();
	}
	
	void FixedUpdate () {
		UpdateInputs();
		UpdateStates();
	}

	private void UpdateInputs() {
		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");

		absoluteMovement = Mathf.Clamp01(Mathf.Abs(vertical) + Mathf.Abs(horizontal));

		playerMovement.HandleMovement(horizontal, vertical);
	}

	private void UpdateStates() {
		stateManager.horizontal = horizontal;
		stateManager.vertical = vertical;

		stateManager.FixedTick(absoluteMovement);
	}
}
