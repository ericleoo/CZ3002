using UnityEngine;
using System.Collections;

public class ControlSettings : MonoBehaviour
{

    public GameObject directControl;
    public GameObject joystickControl;
    public int value;

    void Start ()
    {
        DontDestroyOnLoad(this);
	}
	
	public void OnClick ()
    {
	    if (value == 1)
        {
            directControl.SetActive(false);
            joystickControl.SetActive(true);
            value = 2;
        }

        else 
        {
            directControl.SetActive(true);
            joystickControl.SetActive(false);
            value = 1;
        }
    }
}
