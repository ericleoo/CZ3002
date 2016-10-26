using UnityEngine;
using System.Collections;

public class LeftRacket : MonoBehaviour
{
    void Start()
    {
        //transform.localScale = new Vector3(1.5f, 3);
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

    void FixedUpdate()
    {

        float x, y, dy;
        // x and y are pixels
        x = Input.mousePosition.x;
        y = Input.mousePosition.y;
        dy = Input.GetAxis("Mouse Y");

        if (x <= Screen.width / 2) GetComponent<Rigidbody2D>().position = new Vector2(getX(x), getY(y));

        Debug.Log("x is " + x + ", y is " + y);
    }

}
