using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public GameController gc;
	public GameObject playerPlane;
	public Text healthText;
	public int playerHealth;
	public ParticleSystem damageParticles;
	AudioSource explosion;

	// Use this for initialization
	void Start () {
		gc.setScoreStartedWith (gc.getScore ());
		explosion = gameObject.GetComponent<AudioSource> ();
		UpdateHealthText ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void UpdateHealthText(){
		healthText.text = gc.getUserName() + " Health: " + playerHealth;
	}

	void OnTriggerEnter2D(Collider2D col) {
		//Debug.Log (col.tag);
		if(col.CompareTag("Enemy Bullet")){
			damageParticles.Play ();
			explosion.Play ();
			Destroy (col.gameObject);
			playerHealth--;
			UpdateHealthText ();
			if (playerHealth <= 0) {
				Destroy (playerPlane);
				gc.setScoreBack ();
				gc.reloadLevel ();
			}
		}
	}
}
