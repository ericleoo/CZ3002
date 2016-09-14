using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{

    public float speed = 25;
    void Start()
    {
        Rigidbody2D ball = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(80,100);
        GetComponent<Rigidbody2D>().velocity = speed * Vector2.right;
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }


    public void OnCollisionEnter2D(Collision2D c)
    {
        Rigidbody2D ball = GetComponent<Rigidbody2D>();
        
        ScoreText st = GameObject.Find("Text (1)").GetComponent<ScoreText>();
        HighScore hs = GameObject.Find("Text (2)").GetComponent<HighScore>();
        Fire f = GameObject.Find("fire").GetComponent<Fire>();

        float x = 0;
        if (c.gameObject.name == "WallTop" || c.gameObject.name == "WallLeft" || c.gameObject.name == "WallBottom" || c.gameObject.name == "WallRight")
        {
            hs.saveHighScore();
            SceneManager.LoadScene(1);
            hs.loadHighScore();
        }
        else if (c.gameObject.name == "RacketLeft")
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
        else if (c.gameObject.name == "RacketRight")
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
}
