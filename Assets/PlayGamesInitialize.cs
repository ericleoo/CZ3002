using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class PlayGamesInitialize : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;
		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
