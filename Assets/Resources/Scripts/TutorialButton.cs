using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class TutorialButton : MonoBehaviour {

    public GameObject despawnObject;
    public GameObject spawnObject;
    public GameObject ballObject;
    private Ball ballScript;

	public void OnClick ()
    {
        if (despawnObject) despawnObject.SetActive(false);
        if (spawnObject) spawnObject.SetActive(true);

		if (despawnObject.name == "Tutorial3") {
			// unlock tutorial achievement (achievement ID "CgkItqGWzpUIEAIQAQ")
			Social.ReportProgress("CgkItqGWzpUIEAIQAQ", 100.0f, (bool success) => {
				// handle success or failure
			});

			SceneManager.LoadScene(2);
		}

		if (despawnObject.name == "GameOverWindow")
		{
			SceneManager.LoadScene(2);
		}
	}
	
}
