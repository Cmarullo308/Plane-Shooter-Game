using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float bulletSpeed;
	double distanceBetweenPlanesWhenShot;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (!GameController.paused) {
			transform.Translate (bulletSpeed, 0, 0);
		}
	}

	public void setDistanceBetweenPlanesWhenShot(double distance){
		distanceBetweenPlanesWhenShot = distance;
	}

	public double getDistanceBetweenPlanesWhenShot(){
		return distanceBetweenPlanesWhenShot;
	}
}
