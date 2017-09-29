using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
	
	public float horizontal;
	public float vertical;
	public float totalMovement;
	
	void FixedUpdate () {
		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");

		totalMovement = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
	}
}
