using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour {

	static bool notFirstRun;
	public Button birdToggleButton;

	// Use this for initialization
	void Start () {
		if (!notFirstRun) {
			notFirstRun = true;
			//Default Setings
			PlayerPrefs.SetInt ("BirdEnabled", 1);
		} else {
			//If in the settings Scene
			if (SceneManager.GetActiveScene().name == "Settings") {
				if (PlayerPrefs.GetInt ("BirdEnabled") == 1) {
					birdToggleButton.GetComponentInChildren<Text>().text = "Bird: Enabled";
				} else {
					birdToggleButton.GetComponentInChildren<Text>().text = "Bird: Disabled";
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void toggleBirdEnabled(){
		if (PlayerPrefs.GetInt ("BirdEnabled") == 1) {
			PlayerPrefs.SetInt ("BirdEnabled", 0);
			birdToggleButton.GetComponentInChildren<Text>().text = "Bird: Disabled";
		} else {
			PlayerPrefs.SetInt ("BirdEnabled", 1);
			birdToggleButton.GetComponentInChildren<Text>().text = "Bird: Enabled";
		}
	}

	public bool birdEnabled(){
		if (PlayerPrefs.GetInt ("BirdEnabled") == 1) {
			return true;
		}
		return false;
	}
}
