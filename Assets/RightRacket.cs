using UnityEngine;
using System.Collections;

public class RightRacket : MonoBehaviour
{

    public GameObject center;
    public GameObject otherPaddle;
    public ControlSettings ctrlSet;

    float getEllipseX(double angle)
    {
        return (float)(77 * System.Math.Cos(angle) + 100);
    }


    float getEllipseY(double angle)
    {
        return (float)(41 * System.Math.Sin(angle) + 100);
    }


    float getTheta(float x, float y)
    {
        float theta = (float) System.Math.Acos((x - 100) / 77);
        if (y > 100) theta = -theta;
        return theta;
    }

    void Start()
    {
        //transform.localScale = new Vector3(1.5f, 3);
        //transform.position = new Vector2(getEllipseX(0), getEllipseY(0));
        Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), otherPaddle.GetComponent<BoxCollider2D>());
    }

    float getX(float x)
    {
        // map pixel -> tranform coordinates
        return x / Screen.width * 180.0f + 10.0f;
    }

    float getY(float y)
    {
        // map pixel -> tranform coordinates
        return y / Screen.height * 100.0f + 50.0f;
    }


    float compute(float x, float y)
    {
        return ((x - 100) * (x - 100)) / (77 * 77) + ((y - 100) * (y - 100)) / (41 * 41);
    }

    Vector2 translate(Vector2 p, Vector2 q, float t)
    {
        return new Vector2(p.x + t * (q.x - p.x), p.y + t * (q.y - p.y));
    }

    void updateLocation(float x, float y)
    {
        if (x > Screen.width / 2)
        {
            x = getX(x); y = getY(y);
            Vector2 p = new Vector2(x, y);
            Vector2 q = new Vector2(100, 100);

            Debug.Log(x + " " + y);

            if (175 <= x && x <= 200 && 0 <= y && y <= 70) return;

            if (compute(x, y) > 1)
            {
                float lo = 0, hi = 1;
                for (int i = 0; i < 50; i++)
                {
                    float mid = ((lo + hi)) / 2.0f;
                    Vector2 cur = translate(p, q, mid);
                    if (compute(cur.x, cur.y) > 1) lo = mid;
                    else hi = mid;
                }

                Vector3 touchDir = new Vector3(x, y, 0) - center.transform.position;
                float angle = Mathf.Atan2(touchDir.y, touchDir.x) * Mathf.Rad2Deg;
                Vector3 paddleDir = GetComponent<Rigidbody2D>().transform.position - center.transform.position;
                float angle2 = Mathf.Atan2(paddleDir.y, paddleDir.x) * Mathf.Rad2Deg;

                GetComponent<Rigidbody2D>().transform.RotateAround(GetComponent<Rigidbody2D>().position, Vector3.forward, 180 + (angle - angle2));

                GetComponent<Rigidbody2D>().position = translate(p, q, (lo + hi) / 2.0f);
            }
            else if (compute(x, y) < 1)
            {
                float lo = 0, hi = 1;
                for (int i = 0; i < 50; i++)
                {
                    float mid = ((lo + hi)) / 2.0f;
                    Vector2 cur = translate(q, 1000.0f * (p - q) + q, mid);
                    if (compute(cur.x, cur.y) < 1) lo = mid;
                    else hi = mid;
                }

                Vector3 touchDir = new Vector3(x, y, 0) - center.transform.position;
                float angle = Mathf.Atan2(touchDir.y, touchDir.x) * Mathf.Rad2Deg;
                Vector3 paddleDir = GetComponent<Rigidbody2D>().transform.position - center.transform.position;
                float angle2 = Mathf.Atan2(paddleDir.y, paddleDir.x) * Mathf.Rad2Deg;

                GetComponent<Rigidbody2D>().transform.RotateAround(GetComponent<Rigidbody2D>().position, Vector3.forward, 180 + (angle - angle2));

                GetComponent<Rigidbody2D>().position = translate(q, 1000.0f * (p - q) + q, (lo + hi) / 2.0f);
            }
            else GetComponent<Rigidbody2D>().position = p;

            //GetComponent<Rigidbody2D>().transform.RotateAround(q, Vector3.forward, );
        }
    }

    void FixedUpdate()
    {

        float x, y, dx, dy;
        // x and y are pixels
        x = Input.mousePosition.x;
        y = Input.mousePosition.y;

        bool touch = false;
        bool called = false;

            for (int i = 0; i < Input.touchCount; i++)
            {
                touch = true;
                x = Input.touches[i].position.x;
                y = Input.touches[i].position.y;

                if (x > Screen.width / 2)
                {
                    updateLocation(x, y);
                    called = true;
                }
            }

            if (touch) return;

            updateLocation(x, y);
        
    }
}
