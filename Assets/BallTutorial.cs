using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class BallTutorial : MonoBehaviour
{
    public float initialSpeed = 30;
    public float speed = 30;
    //public float timeToWait = 2;
    public static int numberOfBalls = 1;
    public void Start()
    {
        Time.timeScale = 0;
    }
    
    private void spawnPowerUps(Fire f, Multiply multi)
    {
        if (!f.isActive() && Random.Range(0, 1f) < 0.4f)
        {
            PlayerPrefs.SetFloat("t0", Time.time);
            f.setActive(true);
        }

        if (!multi.isActive() && Random.Range(0, 1f) < 0.4f)
        {
            PlayerPrefs.SetFloat("t1", Time.time);
            multi.setActive(true);
        }
    }

 
    void Update()
    {
        //Debug.Log(speed);
    }
}


