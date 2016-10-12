using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public GameObject gameOverWindow;
    public Text gameOverText;
    public float speed = 0;
    public void GameStart()
    {
        Rigidbody2D ball = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(100,100);
        GetComponent<Rigidbody2D>().velocity = speed * Vector2.right;
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }


    public void OnCollisionEnter2D(Collision2D c)
    {
        Rigidbody2D ball = GetComponent<Rigidbody2D>();
        
        ScoreText st = GameObject.Find("Score").GetComponent<ScoreText>();
        HighScore hs = GameObject.Find("HighScore").GetComponent<HighScore>();
        Fire f = GameObject.Find("fire").GetComponent<Fire>();

        float x = 0;
        if (c.gameObject.name == "WallUp" ||
            c.gameObject.name == "WallLeft" ||
            c.gameObject.name == "WallDown" ||
            c.gameObject.name == "WallRight" )
        {
            speed = 0;
            GameStart();
            GameOver();
            //speed = 30;
            //GameStart();
            return;
        }
        else if (c.gameObject.name == "LeftRacket")
        {
            st.incScore();
            hs.setHighScore(st.getScore());
            x = 1;
            
            if(!f.isActive() && Random.Range(0,1f) < 0.8f)
            {
                PlayerPrefs.SetFloat("t0", Time.time);
                f.setActive(true);
            }
        }
        else if (c.gameObject.name == "RightRacket")
        {
            st.incScore();
            hs.setHighScore(st.getScore());
            x = -1;

            if (!f.isActive() && Random.Range(0, 1f) < 0.8f)
            {
                PlayerPrefs.SetFloat("t0", Time.time);
                f.setActive(true);
            }
        }
        else if(c.gameObject.name == "fire")
        {
            f.setActive(false);
            speed *= 2.0f;
            ball.velocity = 2.0f * ball.velocity;
            return;
        }
        else return;

        ball.velocity = speed * new Vector2(x, hitFactor(ball.position, c.transform.position, c.collider.bounds.size.y)).normalized;
    }

    void GameOver()
    {
        transform.position = new Vector2(100, 100);
        speed = 0;
        gameOverWindow.active = true;
        ScoreText st = GameObject.Find("Score").GetComponent<ScoreText>();
        HighScore hs = GameObject.Find("HighScore").GetComponent<HighScore>();
        gameOverText.text = "Game Over!\nYour Score: " + st.getScore() + "\nHigh Score: " + hs.getHighScore();
        hs.saveHighScore();
        //SceneManager.LoadScene(1);
        hs.loadHighScore();
        st.resetScore();
    }
    void Update()
    {
        Debug.Log(speed);
    }
}


