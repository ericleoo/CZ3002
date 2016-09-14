using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScore : MonoBehaviour {

    private int highScore;

    void Awake()
    {
        //DontDestroyOnLoad(this);
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("High Score"))
            highScore = PlayerPrefs.GetInt("High Score");
        else highScore = 0;
    }
	
    void FixedUpdate()
    {
        GetComponent<Text>().text = "HIGH SCORE: " + highScore;
    }

    public void setHighScore(int x)
    {
        if (highScore < x) highScore = x;
    }

    public int getHighScore() { return highScore; }

    public void saveHighScore()
    {
        PlayerPrefs.SetInt("High Score", highScore);
    }

    public void loadHighScore()
    {
        highScore = PlayerPrefs.GetInt("High Score");
    }
}
