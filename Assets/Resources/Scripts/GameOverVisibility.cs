using UnityEngine;
using System.Collections;

public class GameOverVisibility : MonoBehaviour {
	private GameObject gameOverWindow;
	// Use this for initialization
	void Start () {
		gameOverWindow = GameObject.Find ("GameOverWindow");
	}
	
	// Update is called once per frame
	/*void Update () {
		Debug.Log ("here");
		foreach (Transform child in this.transform)
		{
			if (PlayerPrefs.GetInt ("GameOver") == 1)
			{
				child.gameObject.SetActive(true);
			}
			else
			{
				child.gameObject.SetActive(false);
			}
		}
	}*/

	public void showWindow(bool status){
		gameOverWindow.SetActive (status);
	}

}
