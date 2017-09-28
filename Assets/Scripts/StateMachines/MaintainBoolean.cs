using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintainBoolean : StateMachineBehaviour {
	public bool resetOnStateExit;
	public string booleanName;
	public bool booleanState;

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.SetBool(booleanName, booleanState);
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if(resetOnStateExit) {
			animator.SetBool(booleanName, !booleanState);
		}
	}
}
