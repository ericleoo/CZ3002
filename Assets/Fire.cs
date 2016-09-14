using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

    public bool active = false;

    void Start()
    {
        if(!active) transform.localScale = new Vector3(0, 0);
    }
	
    // Update is called once per frame
	void Update ()
    {
        //if (active && Time.time - PlayerPrefs.GetFloat("t0") > 5) active = false;

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        if (active && Time.time - PlayerPrefs.GetFloat("t0") > 10) active = false;

        if (!active) transform.localScale = new Vector3(0, 0);
        else transform.localScale = new Vector3(20,20);
    }

    public bool isActive() { return active; }
    public void setActive(bool b) {
        if(b) transform.position = new Vector2(Random.Range(38, 163), Random.Range(80, 119));
        active = b;
    }
}
