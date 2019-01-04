using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour {

	public GameController gc;
	public Settings settings;

	bool facingRight;
	bool goingUp;
	bool startedFacingRight;
	float xMovement;
	float yMovement;

	// Use this for initialization
	void Start () {
		if (!settings.birdEnabled()) {
			gameObject.SetActive (false);
		} else {
			facingRight = true;
			goingUp = true;
			xMovement = 0.20f;
			yMovement = 0.10f;

			if (facingRight) {
				transform.Rotate (0, 180, 0);
				startedFacingRight = true;
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (!GameController.isPaused()) { //While the game isnt paused
			if (facingRight && goingUp) {
				checkPosition ();
				transform.Translate (-xMovement, yMovement, 0);
			} else if (facingRight && !goingUp) {
				checkPosition ();
				transform.Translate (-xMovement, -yMovement, 0);
			} else if (!facingRight && goingUp) {
				checkPosition ();
				transform.Translate (-xMovement, yMovement, 0);
			} else if (!facingRight && !goingUp) {
				checkPosition ();
				transform.Translate (-xMovement, -yMovement, 0);
			}
		}
	}

	void checkPosition(){
		if (transform.position.x > 9 && facingRight == true && startedFacingRight) {
			flip ();
		} else if (transform.position.x < -9 && facingRight == false && startedFacingRight) {
			flip ();
		} else if (transform.position.x > 9 && facingRight == true && !startedFacingRight) {
			flip ();
		} else if (transform.position.x < -9 && facingRight == false && !startedFacingRight) {
			flip ();
		}

		else if (transform.position.y > 5 && goingUp) {
			goingUp = false;
		}

		else if (transform.position.y < -5 && !goingUp) {
			goingUp = true;
		}
	}

	void flip(){
		facingRight = !facingRight;
		transform.Rotate (0, 180, 0);
	}

	void print(string message) {
		Debug.Log (message);
	}
}
