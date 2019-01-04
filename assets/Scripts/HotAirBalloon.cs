using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotAirBalloon : MonoBehaviour {

	public float XSpeed;
	public float ySpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameController.isPaused ()) {
			transform.Translate (-XSpeed, ySpeed, 0);

			if (transform.position.y > 8) {
				transform.position = new Vector3(transform.position.x, -8, 0);
			}
			if (transform.position.x < -11) {
				transform.position = new Vector3 (11, transform.position.y, 0);
			}
		}
	}
}

