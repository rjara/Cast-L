using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerWalk))]
public class PlayerInputController : MonoBehaviour {

	// Movement input signals
	public bool inUp = false, inDown = false, inLeft = false, inRight = false;
	
	PlayerWalk walkScript;
	PlayerPawnController pawnController;

	void Start () {
		walkScript = GetComponent<PlayerWalk>();
		pawnController = GetComponentInChildren<PlayerPawnController>();
	}

	void FixedUpdate () {
		walkScript.Walk(WalkInputProcess());
		WalkAnimationProcess(WalkInputProcess());
	}

	// Process Input signals
	Vector2 WalkInputProcess() {
		int hVelocity = 0, vVelocity = 0;

		if(inRight) {
			hVelocity += 1;
		}
		if(inLeft) {
			hVelocity -= 1;
		}
		if(inUp) {
			vVelocity += 1;
		}
		if(inDown) {
			vVelocity -= 1;
		}

		return new Vector2(hVelocity, vVelocity);
	}

	// Process movement input results
	void WalkAnimationProcess(Vector2 vel) {
		if (vel != Vector2.zero) {
			pawnController.SetWalking(true);
		} else {
			pawnController.SetWalking(false);
		}

		pawnController.Flip(vel.x);
	}
}
