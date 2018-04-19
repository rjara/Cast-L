using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerWalk : MonoBehaviour {

	public float walkSpeed = 2.5f;

	Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	public void Walk(Vector2 vel) {
		rb.velocity = vel.normalized * walkSpeed;
	}
}
