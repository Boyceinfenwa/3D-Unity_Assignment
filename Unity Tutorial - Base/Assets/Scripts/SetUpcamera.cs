using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpcamera : MonoBehaviour {

    public Camera FollowCam;
    public Camera StaticCam;
    public Camera PiPcam;
    
    // Use this for initialization
	void Start ()
    {
        GameObject PlayerCharacter = GameObject.FindGameObjectWithTag("Player");

        FollowCam.enabled = true;
        StaticCam.enabled = false;
        PiPcam.enabled = true;

        PlayerCharacter.GetComponent<AudioListener>().enabled = true;
        StaticCam.GetComponent<AudioListener>().enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyUp("p"))
        {
            PiPcam.enabled = !PiPcam.enabled;
        }
	}
}
