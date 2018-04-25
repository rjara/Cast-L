using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerWalk))]
public class PlayerInputController : MonoBehaviour {

	// Movement input signals
	public bool inUp = false, inDown = false, inLeft = false, inRight = false;
	// Action Input
	public bool inActionA = false;
	
	bool actionACooldown;
	public float actionACooldownTime_DEV = 2f;

	// Instantiate components
	PlayerWalk walkScript;
	PlayerAttack attackScript;
	PlayerPawnController pawnController;

	void Start () {
		// Initialize states
		actionACooldown = false;

		// Initialize components
		walkScript = GetComponent<PlayerWalk>();
		attackScript = GetComponent<PlayerAttack>();
		pawnController = GetComponentInChildren<PlayerPawnController>();
	}

	void FixedUpdate () {
		walkScript.Walk(WalkInputProcess());
		WalkAnimationProcess(WalkInputProcess());
	}

	void Update () {
		attackScript.Attack(ActionAInputProcess());
	}

	// Process movement input signals
	Vector2 WalkInputProcess () {
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

	// Process attack input signals
	bool ActionAInputProcess () {
		if(inActionA) {
			bool canAttack = false;

			if(!actionACooldown) {
				actionACooldown = true;
				canAttack = true;
				Invoke("ResetActionACooldown", actionACooldownTime_DEV);
			}

			inActionA = false;

			return canAttack;
		}
		return false;
	}

	// Process movement input results
	void WalkAnimationProcess (Vector2 vel) {
		if (vel != Vector2.zero) {
			pawnController.SetWalking(true);
		} else {
			pawnController.SetWalking(false);
		}

		pawnController.Flip(vel.x);
	}

	// Resets action A timer
	void ResetActionACooldown () {
		actionACooldown = false;
	}
}
