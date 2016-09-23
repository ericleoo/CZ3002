using UnityEngine;
using System.Collections;

public class RacketRight : MonoBehaviour
{
    public float speed = 7.5f;
    public int state;
    void Start()
    {
        transform.position = new Vector2(178, Random.Range(61, 139));
        state = 0;
    }

    void FixedUpdate()
    {

        if (state == 0)
        {
            float x, dy;
            bool touch = false;
            bool called = false;

            for (int i = 0; i < Input.touchCount; i++)
            {
                touch = true;
                x = Input.touches[i].position.x;
                dy = Input.touches[i].deltaPosition.y;

                if (x > Screen.width / 2)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, dy) * speed;
                    called = true;
                }
            }

            if (touch && !called)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            if (touch) return;

            x = Input.mousePosition.x;
            dy = Input.GetAxis("Mouse Y");

            if (x <= Screen.width / 2) GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            else GetComponent<Rigidbody2D>().velocity = new Vector2(0, dy) * speed;
        }
        else if (state == 1)
        {
            float dx, x;
            bool touch = false;
            bool called = false;

            for (int i = 0; i < Input.touchCount; i++)
            {
                touch = true;
                x = Input.touches[i].position.x;
                dx = Input.touches[i].deltaPosition.x;

                if (x > Screen.width / 2)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(dx, 0) * speed;
                    called = true;
                }
            }

            if (touch && !called)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            if (touch) return;

            x = Input.mousePosition.x;
            dx = Input.GetAxis("Mouse X");

            if (x <= Screen.width / 2) GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            else GetComponent<Rigidbody2D>().velocity = new Vector2(dx, 0) * speed;
        }
    }

    public void OnCollisionEnter2D(Collision2D c)
    {
        if (state == 0 && (c.gameObject.name == "WallTop" || c.gameObject.name == "WallBottom"))
        {
            state = 1;
            transform.Rotate(new Vector3(0, 0, 90));
        }
        else if (state == 1 && c.gameObject.name == "WallRight")
        {
            state = 0;
            transform.Rotate(new Vector3(0, 0, 90));
        }
    }
}