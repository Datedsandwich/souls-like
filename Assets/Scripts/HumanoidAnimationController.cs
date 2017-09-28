using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidAnimationController : MonoBehaviour {

	[Range(0, 1)]
	public float vertical;

	[Range(0, 1)]
	public float horizontal;

	[Range(0, 1)]
	public int weaponType;

	public bool isApplyingRootMotion;
	public bool isAttacking;

	public string[] oneHandedAttacks;
	public string[] twoHandedAttacks;

	private Animator animator;

	void Start () {
		animator = GetComponent<Animator>();
	}
	
	void Update () {
		isApplyingRootMotion = animator.GetBool("ApplyRootMotion");
		animator.applyRootMotion = isApplyingRootMotion;

		if(isApplyingRootMotion) {
			return;
		}

		animator.SetInteger("WeaponType", weaponType);

		if(isAttacking) {
			string targetAnimation;

			if(weaponType == 0) {
				int attack = Random.Range(0, oneHandedAttacks.Length);
				targetAnimation = oneHandedAttacks[attack];
			} else {
				int attack = Random.Range(0, twoHandedAttacks.Length);
				targetAnimation = twoHandedAttacks[attack];
			}

			vertical = 0;
			animator.CrossFade(targetAnimation, 0.2f);
			animator.SetBool("ApplyRootMotion", true);
			isAttacking = false;
		} else {
			animator.SetFloat("Vertical", vertical);
			animator.SetFloat("Horizontal", horizontal);
		}
	}
}
