using UnityEngine;
using System.Collections;

public class Multiply : Fire {

    void Update()
    {
        //if (active && Time.time - PlayerPrefs.GetFloat("t0") > 5) active = false;

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        if (active && Time.time - PlayerPrefs.GetFloat("t1") > 10) active = false;

        if (!active) transform.localScale = new Vector3(0, 0);
        else transform.localScale = new Vector3(20, 20);
    }
}
