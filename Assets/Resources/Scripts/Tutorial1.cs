using UnityEngine;
using System.Collections;

public class Tutorial1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Stop gameplay during tutorial
		PlayerPrefs.SetInt("tutorial", 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
