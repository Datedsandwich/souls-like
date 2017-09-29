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
	
	void FixedUpdate () {
		horizontal = Input.GetAxis(GlobalInputs.horizontal);
		vertical = Input.GetAxis(GlobalInputs.vertical);
		totalMovement = Mathf.Abs(horizontal) + Mathf.Abs(vertical);

		isSprinting = Input.GetButton(GlobalInputs.sprint);
	}
}
