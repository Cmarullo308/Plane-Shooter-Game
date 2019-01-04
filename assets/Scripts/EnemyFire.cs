using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour {

	public Transform bulletSpawn;
	public GameObject bulletPrefab;
	public float fireRate;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Fire", 2.0f, fireRate);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Fire(){
		if (!GameController.isPaused ()) {
			//create a bullet from the bullet prefab
			var bullet = (GameObject)Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

			// Destroy the bullet after 2 seconds
			Destroy (bullet, 2.0f);
		}
	}
}
