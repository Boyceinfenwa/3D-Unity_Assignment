using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camtrigger : MonoBehaviour
{

    public Camera triggeredCamera;
    public Camera liveCam;

    private void OnTriggerEnter(Collider other)
    {
        GameObject PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        Collider PlayerCollider = PlayerCharacter.GetComponent<Collider>();

        if (other == PlayerCollider)
        {
            liveCam = Camera.allCameras [0];

            triggeredCamera.enabled = true;
            liveCam.enabled = false;

            triggeredCamera.GetComponent<AudioListener> ().enabled = true;
            PlayerCharacter.GetComponent<AudioListener> ().enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {

    }
    private void OnTriggerStay(Collider other)
    {

    }
}