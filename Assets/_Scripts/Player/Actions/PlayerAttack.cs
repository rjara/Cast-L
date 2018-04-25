using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	public GameObject weapon;

	public void Attack (bool doAttack) {
		if (doAttack) {
			weapon.SetActive(true);
			Invoke("EndAttack", .5f);
		}
	}

	void EndAttack () {
		weapon.SetActive(false);
	}
}
