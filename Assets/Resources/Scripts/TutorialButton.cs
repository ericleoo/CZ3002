using UnityEngine;
using System.Collections;

public class TutorialButton : MonoBehaviour {

    public GameObject despawnObject;
    public GameObject spawnObject;
    public GameObject ballObject;
    private Ball ballScript;

	public void OnClick ()
    {
        if (despawnObject) despawnObject.SetActive(false);
        if (spawnObject) spawnObject.SetActive(true);

        if (despawnObject.name == "Tutorial3")
        {
            ballScript = ballObject.GetComponent<Ball>();
			PlayerPrefs.SetInt ("tutorial", 0);
            ballScript.Start();
        }

        if (despawnObject.name == "GameOverWindow")
        {
			ballScript = ballObject.GetComponent<Ball>();
            ballScript.Start();
        }
	}
	
}
