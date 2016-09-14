using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreText : MonoBehaviour {
    private int score = 0;
	// Update is called once per frame

	void FixedUpdate () {
        GetComponent<Text>().text = "SCORE: " + score;
    }

    public void incScore() { score++; }
    public void resetScore() { score = 0; }
    public int getScore() { return score; }
}
