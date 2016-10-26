using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {
    public void playButton() { SceneManager.LoadScene(2); }
    public void tutorialButton() { SceneManager.LoadScene(1); }
}
