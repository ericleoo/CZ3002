using UnityEngine;
using System.Collections;

public class GameOverWindow : MonoBehaviour {
	public GameObject gameOverWindow;

	// Use this for initialization
	void Start () {
		gameOverWindow = GameObject.Find ("GameOverWindow");
		gameOverWindow.SetActive (false);
	}

}
