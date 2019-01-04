using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static bool paused;
	public Canvas pauseMenu;

	public static double screenX = 9;
	public static double screenY = 5;

	public string currentLevelName;
	public string nextLevel;
	static string userName;
	static int score;
	static int scoreStartedLevelWith;
	public Text ScoreText;

	public Text HighScoreMenuText;

	// Use this for initialization
	void Start () {
		paused = false;

		if (PlayerPrefs.GetInt ("FirstGameControllerRun") == 0) {
			PlayerPrefs.SetInt ("FirstGameControllerRun", 1);
			score = 0;
		}

		if(SceneManager.GetActiveScene().name.Equals("HighScores")){
			UpdateHighScoreMenuText();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			if (!paused) {
				paused = true;
				pauseMenu.gameObject.SetActive (true);
			} else {
				paused = false;
				pauseMenu.gameObject.SetActive (false);
			}
		}
	}

	public void unPause(){
		paused = false;
		pauseMenu.gameObject.SetActive (false);
	}

	public void reloadLevel(){
		SceneManager.LoadScene (currentLevelName);
	}

	public void goToScene(string scene)
	{
		SceneManager.LoadScene (scene);
	}

	public void quitGame(){
		Application.Quit ();
	}

	public void setUserName(string name){
			userName = name;
	}

	public void checkUserName(){
		if (userName == null || userName.Length < 1) {
			userName = "Player";
		}
	}

	public string getUserName(){
		return userName;
	}

	public void setScore(int newScore){
		score = newScore;
	}

	public int getScore(){
		return score;
	}

	public void setScoreStartedWith(int tempScore){
		scoreStartedLevelWith = tempScore;
	}

	public int getScoreStartedWith(){
		return scoreStartedLevelWith;
	}

	//Sets the score back to what it was before the level started
	public void setScoreBack(){
		score = scoreStartedLevelWith;
	}

	public void checkHighScore(){
		int[] scoreArr = new int[6]; 
		//Makes an array of all 5 high scores plus the current score in the last slot
		for (int i = 1; i <= scoreArr.Length - 1; i++) {
			scoreArr [i-1] = PlayerPrefs.GetInt ("HighScore " + i.ToString ());
		}
		scoreArr [5] = score;

		//Sorts the array
		sortArray (scoreArr);

		//Puts back the 5 highest scores and knocks off the lowest (the 6th in the array)
		for (int i = 1; i <= 5; i++) {
			PlayerPrefs.SetInt ("HighScore " + i, scoreArr [i - 1]);
		}
	}

	private void sortArray(int[] arr){
		bool swapped;
		do {
			swapped = false;
			for (int i = 0; i < arr.Length - 1; i++) {
				if (arr [i] < arr [i + 1]) {
					int temp = arr [i];
					arr [i] = arr [i + 1];
					arr [i + 1] = temp;
					swapped = true;
				}
			}
		} while(swapped);
	}

	public int getHighScore(){
		return PlayerPrefs.GetInt ("HighScore 1");
	}

	public void UpdateScoreText(){
		//string temp = "";
		ScoreText.text = "HighScore: " + PlayerPrefs.GetInt ("HighScore 1") +"\nScore: " + score +  "\n" + SceneManager.GetActiveScene().name;
		//temp += "HighScore: " + PlayerPrefs.GetInt ("HighScore 1") +"\nScore: " + score +  "\n" + SceneManager.GetActiveScene().name;
	}

	public static bool isPaused(){
		return paused;
	}

	public void UpdateHighScoreMenuText(){
		HighScoreMenuText.text = "";
		HighScoreMenuText.text += "First: " + PlayerPrefs.GetInt ("HighScore 1").ToString() + "\n";
		HighScoreMenuText.text += "Second: " + PlayerPrefs.GetInt ("HighScore 2").ToString()+ "\n";
		HighScoreMenuText.text += "Third: " + PlayerPrefs.GetInt ("HighScore 3").ToString()+ "\n";
		HighScoreMenuText.text += "Forth: " + PlayerPrefs.GetInt ("HighScore 4").ToString()+ "\n";
		HighScoreMenuText.text += "Fifth: " + PlayerPrefs.GetInt ("HighScore 5").ToString()+ "\n";
		//Debug.Log (2 + ": " + PlayerPrefs.GetInt ("HighScore 2").ToString () + "\n");
	}

	public void clearScoreData(){
		PlayerPrefs.SetInt ("HighScore 1", 0);
		PlayerPrefs.SetInt ("HighScore 2", 0);
		PlayerPrefs.SetInt ("HighScore 3", 0);
		PlayerPrefs.SetInt ("HighScore 4", 0);
		PlayerPrefs.SetInt ("HighScore 5", 0);
	}
}
