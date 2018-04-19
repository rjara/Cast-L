using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPawnController : MonoBehaviour {

	bool lookingRight = true;
	bool isWalking = false;
	Animator upperBody;
	Animator legs;

	void Start () {
		GetChildrenAnims();
	}

	// Set Animator parameter "Walking" for all animator components
	public void SetWalking(bool walking) {
		isWalking = walking;
		upperBody.SetBool("Walking", isWalking);
		legs.SetBool("Walking", isWalking);
	}

	// Logic for mirroring the sprite horizontally according to velocity sign and current facing side
	public void Flip (float xVelocity) {
		if (xVelocity > 0 && !lookingRight) {
			lookingRight = true;
			transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
		} else if (xVelocity < 0 && lookingRight) {
			lookingRight = false;
			transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1f, transform.localScale.y, transform.localScale.z);
		}
	}

	// Get Animator component for the independent parts of the pawn
	void GetChildrenAnims () {
		foreach (Transform child in transform) {
			if(child.gameObject.name.Equals("UpperBody")) {
				upperBody = child.gameObject.GetComponent<Animator>();
			}
			else if(child.gameObject.name.Equals("Legs")) {
				legs = child.gameObject.GetComponent<Animator>();
			}
		}
	}
}
