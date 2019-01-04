using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlaneControls : MonoBehaviour {
	//Animation
	Animator animator;
	//Movement
	bool isFacingRight;
	bool goingUp;
	bool goingDown;
	public float speed;
	double xLimit;
	double yLimit;
	// Use this for initialization
	void Start () {
		isFacingRight = true;
		goingUp = false;
		goingDown = false;
		xLimit = GameController.screenX - 0.5;
		yLimit = GameController.screenY;
		animator = gameObject.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		if (!GameController.isPaused ()) {

			//Move Left
			if (Input.GetKey (KeyCode.LeftArrow)) {
				if (isFacingRight) {
					flip ();
				}
				//Debug.Log (xLimit);
				if (transform.position.x > -xLimit) {
					transform.Translate (speed, 0, 0);
				}
			} 

			//Move Down
			if (Input.GetKey (KeyCode.DownArrow)) {
				if (transform.position.y > -yLimit) {
					transform.Translate (0, -speed, 0);
				}
				goingDown = true;
			} else {
				goingDown = false;
			}


			//Move Up
			if (Input.GetKey (KeyCode.UpArrow)) {
				if (transform.position.y < yLimit) {
					transform.Translate (0, speed, 0);
				}
				goingUp = true;
			} else {
				goingUp = false;
			}

			//Move Right
			if (Input.GetKey (KeyCode.RightArrow)) {
				if (!isFacingRight) {
					flip ();
				}
				if (transform.position.x < xLimit) {
					transform.Translate (speed, 0, 0);
				}
			} 

			//Debug
			if(Input.GetKey (KeyCode.D)){
				//Debug.Log(transform.position);
			}

			//Animations
			if (goingUp) {
				animator.Play ("Plane-Up");
			} else if (goingDown) {
				animator.Play ("Plane-Down");
			} else {
				animator.Play ("Still");
			}
		}
	}

	void flip(){
		isFacingRight = !isFacingRight;
		transform.Rotate (0, 180, 0);
	}
}
