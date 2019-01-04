using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

	public Transform bulletSpawn;
	public GameObject bulletPrefab;
	public double fireRate;
	double lastShot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space)){
			fire ();
		}
	}

	void fire(){
		if (!GameController.isPaused ()) {
			//Limit rate of fire
			if (Time.time > fireRate + lastShot) {
				//create a bullet from the bullet prefab
				GameObject bullet = Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
				lastShot = Time.time;
				// Destroy the bullet after 2 seconds
				Destroy (bullet, 2.0f);
			}
		}
	}
}
