using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
	
	public float horizontal {
		get; private set;
	}
	public float vertical {
		get; private set;
	}
	public float totalMovement {
		get; private set;
	}
	public bool isSprinting {
		get; private set;
	}

	public bool lightAttack {
		get; private set;
	}
	public bool heavyAttack {
		get; private set;
	}
	public bool block {
		get; private set;
	}
	public bool parry {
		get; private set;
	}
	
	void FixedUpdate () {
		GetMovementInputs();
		GetCombatInputs();
	}

	private void GetMovementInputs() {
		horizontal = Input.GetAxis(GlobalInputs.horizontal);
		vertical = Input.GetAxis(GlobalInputs.vertical);
		totalMovement = Mathf.Abs(horizontal) + Mathf.Abs(vertical);

		isSprinting = Input.GetButton(GlobalInputs.sprint);
	}

	private void GetCombatInputs() {
		lightAttack = Input.GetButtonDown(GlobalInputs.lightAttack);
		heavyAttack = Input.GetButtonDown(GlobalInputs.heavyAttack);
		parry = Input.GetButtonDown(GlobalInputs.parry);

		// Block can be held down
		block = Input.GetButton(GlobalInputs.block);
	}
}
