using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public GameObject gameOverWindow;
    public Text gameOverText;
    public float speed = 30;
    //public float timeToWait = 2;
    public static int numberOfBalls = 1;
    public void Start()
    {
        // Only the first ball gets the following setup
        if (numberOfBalls == 1)
        {
            Time.timeScale = 1;
            Rigidbody2D ball = GetComponent<Rigidbody2D>();
            transform.position = new Vector2(100, 100);
            ball.velocity = speed * Vector2.right;
        }
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
        Multiply multi = GameObject.Find("Multiply").GetComponent<Multiply>();

        float x = 0;

        if (c.gameObject.name == "Ellipse")
        {
            if (numberOfBalls == 1)
            {
                GameOver();
            }
            else
            {
                Destroy(ball.gameObject);
                numberOfBalls--;
            }

        }
        
        else if (c.gameObject.name == "LeftRacket")
        {
            st.incScore();
            hs.setHighScore(st.getScore());
            x = 1;
            spawnPowerUps(f, multi);
        }
        else if (c.gameObject.name == "RightRacket")
        {
            st.incScore();
            hs.setHighScore(st.getScore());
            x = -1;
            spawnPowerUps(f, multi);
        }
        else if(c.gameObject.name == "fire")
        {
            f.setActive(false);
            speed *= 2.0f;
            ball.velocity = 2.0f * ball.velocity;
            return;
        }
        else if (c.gameObject.name == "Multiply")
        {
            multi.setActive(false);

            // Wait 2 seconds
            //BlinkAndWait();

            // The original ball goes to the left, instantiate a new ball and make it go right
            ball.velocity = speed * Vector2.left;
            GameObject newBall = (GameObject)Instantiate(Resources.Load("Prefabs/Ball"), transform.position, Quaternion.identity);
            numberOfBalls++;
            newBall.GetComponent<Rigidbody2D>().velocity = speed * Vector2.right;

            /*
            // The original ball keeps moving, instantiated ball moves at the opposite direction
            GameObject newBall = (GameObject)Instantiate(Resources.Load("Prefabs/Ball"), transform.position, Quaternion.identity);
            numberOfBalls++;
            Vector2 reverseDirection = -transform.forward;
            newBall.GetComponent<Rigidbody2D>().velocity = speed * reverseDirection;
            */
            return;
        }

        else return;

        ball.velocity = speed * new Vector2(x, hitFactor(ball.position, c.transform.position, c.collider.bounds.size.y)).normalized;
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

    /*
    private void BlinkAndWait()
    {
        GetComponent<Rigidbody2D>().SetActive(false);
        float timer = Time.deltaTime;
        while (timeToWait != 0)
        {
            GetComponent<GameObject>().SetActive(true);
            if (timer == 1)
            {
                GetComponent<GameObject>().SetActive(false);
                timer = 0;
                timeToWait--;
            }
        }
    }
    */

    void GameOver()
    {
        Time.timeScale = 0;
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


