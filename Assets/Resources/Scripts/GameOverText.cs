using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverText : MonoBehaviour {
	//Do not use awake, then use what?
	void Update () {
		ScoreText st = GameObject.Find("Score").GetComponent<ScoreText>();
		GetComponent<Text>().text = "Game Over!\nYour Score: " + st.getLastScore() + "\nHigh Score: " + PlayerPrefs.GetInt("High Score");
	}
}
