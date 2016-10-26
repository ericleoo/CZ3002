using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TutorialButton : MonoBehaviour {

    public GameObject despawnObject;
    public GameObject spawnObject;
    public GameObject ballObject;
    private Ball ballScript;

	public void OnClick ()
    {
        if (despawnObject) despawnObject.SetActive(false);
        if (spawnObject) spawnObject.SetActive(true);

        if (despawnObject.name == "Tutorial3" || despawnObject.name == "GameOverWindow")
        {
            SceneManager.LoadScene(2);
        }
	}
	
}
