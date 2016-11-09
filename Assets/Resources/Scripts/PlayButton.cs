using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class PlayButton : MonoBehaviour {

    public ControlSettings CtrlSet;
    public void playButton()
    {
        if (CtrlSet.value == 1) SceneManager.LoadScene(2);
        else if (CtrlSet.value == 2) SceneManager.LoadScene(3);
    }
    public void tutorialButton() { SceneManager.LoadScene(1); }
	public void loginButton() {
		// authenticate user:
		Social.localUser.Authenticate((bool success) => {
			// handle success or failure
		});
	}
}
