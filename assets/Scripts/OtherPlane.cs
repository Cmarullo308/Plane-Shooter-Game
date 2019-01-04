using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherPlane : MonoBehaviour {

	//Movement
	public Transform player;
	public float xSpeed;
	public float ySpeed;
	bool goingUp;
	bool goingDown;
	bool facingRight;
	public bool followMode;
	double xLimit;
	double yLimit;
	//Animation
	Animator animator;

	// Use this for initialization
	void Start () {
		facingRight = true;
		goingUp = true;
		goingDown = false;
		xLimit = GameController.screenX;
		yLimit = GameController.screenY;
		animator = gameObject.GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (!GameController.isPaused ()) { //If the game isnt paused
			//Directions
			checkPosition ();


			//Move
			if (facingRight && goingUp) {
				//checkPosition ();
				transform.Translate (xSpeed, ySpeed, 0);
			} else if (facingRight && !goingUp) {
				//checkPosition ();
				transform.Translate (xSpeed, -ySpeed, 0);
			} else if (!facingRight && goingUp) {
				//checkPosition ();
				transform.Translate (xSpeed, ySpeed, 0);
			} else if (!facingRight && !goingUp) {
				//checkPosition ();
				transform.Translate (xSpeed, -ySpeed, 0);
			}

			if (goingUp) {
				animator.Play ("Plane-Up");
			} else if (goingDown) {
				animator.Play ("Plane-Down");
			}
		}
	}

	void checkPosition(){
		if (player != null && followMode) {
			if (player.position.x - 7 > transform.position.x) {
				if (!facingRight) {
					flip ();
				}
			} 
			if (player.position.x + 7 < transform.position.x) {
				if (facingRight) {
					flip ();
				}
			} 
			if (player.position.y - 1 > transform.position.y) {
				if (!goingUp) {
					goingUp = true;
					goingDown = false;
				}
			} 
			if (player.position.y + 1 < transform.position.y) {
				if (goingUp) {
					goingUp = false;
					goingDown = true;
				}
			}
		} else {

			if (transform.position.x > xLimit && facingRight == true) {
				flip ();
			} else if (transform.position.x < -xLimit && facingRight == false) {
				flip ();
			} else if (transform.position.y > yLimit && goingUp) {
				goingUp = false;
				goingDown = true;
			} else if (transform.position.y < -yLimit && !goingUp) {
				goingUp = true;
				goingDown = false;
			}
		}
	}

	void flip(){
		facingRight = !facingRight;
		transform.Rotate (0, 180, 0);
	}

	void print(string message){
		Debug.Log (message);
	}
}
