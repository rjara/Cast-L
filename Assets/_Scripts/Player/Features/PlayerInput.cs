using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	KeyCode up = KeyCode.None, down = KeyCode.None, left = KeyCode.None, right = KeyCode.None;
	KeyCode actionA = KeyCode.None;

	GameObject player;
	PlayerInputController inputController;

	void Start () {
		player = GetPlayerObject();
		inputController = player.GetComponent<PlayerInputController>();

		/*
		TEMPORARY BUTTON MAPPING
		*/
		up = KeyCode.W;
		down = KeyCode.S;
		left = KeyCode.A;
		right = KeyCode.D;
		actionA = KeyCode.Space;
	}
	
	void FixedUpdate () {
		MovementInput();
		ActionInput();
	}

	void MovementInput () {
		if (Input.GetKey(up)) {
			inputController.inUp = true;
		} else {
			inputController.inUp = false;
		}

		if(Input.GetKey(down)) {
			inputController.inDown = true;
		} else {
			inputController.inDown = false;
		}

		if(Input.GetKey(left)) {
			inputController.inLeft = true;
		} else {
			inputController.inLeft = false;
		}

		if(Input.GetKey(right)) {
			inputController.inRight = true;
		} else {
			inputController.inRight = false;
		}
	}

	void ActionInput () {
		if (Input.GetKeyDown(actionA)) {
			inputController.inActionA = true;
		}
	}

	GameObject GetPlayerObject () {
		if(gameObject.name.Equals("InputA")) {
			return GameObject.Find("PlayerA");
		}
		else if(gameObject.name.Equals("InputB")) {
			return GameObject.Find("PlayerB");
		}
		else {
			return null;
		}
	}
}
