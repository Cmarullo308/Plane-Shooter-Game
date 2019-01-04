using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPlaneHealth : MonoBehaviour {

	public GameController gc;
	public GameObject EnemyPlane;
	public GameObject Player;
	public Text HealthText;
	public Text ScoreText;
	public int health;
	public ParticleSystem damageParticles;
	AudioSource explosion;

	// Use this for initialization
	void Start () {
		explosion = gameObject.GetComponent<AudioSource> ();
		UpdateHealthText ();
		gc.UpdateScoreText ();
	}

	// Update is called once per frame
	void Update () {

	}

	void UpdateHealthText(){
		HealthText.text = "Enemey Health: " + health;
	}

	void OnTriggerEnter2D(Collider2D col) {
		double planeDistance = Vector3.Distance (EnemyPlane.transform.position, Player.transform.position);

		//Debug.Log (col.tag);
		if (col.CompareTag ("Bullet")) {
			damageParticles.Play ();
			explosion.Play ();
			Destroy (col.gameObject);
			health--;
			UpdateHealthText ();
			if (planeDistance <= 4) {
				gc.setScore (gc.getScore () + 1);
			} else if (planeDistance <= 7) {
				gc.setScore (gc.getScore () + 2);
			} else {
				gc.setScore (gc.getScore () + 3);
			}
			gc.UpdateScoreText ();
			if (health <= 0) {
				
				Destroy (EnemyPlane);
				new WaitForSeconds (2);
				gc.goToScene(gc.nextLevel);
			}
		}
	}
}
