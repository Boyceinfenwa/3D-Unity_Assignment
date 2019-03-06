using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCollision : MonoBehaviour {

    public float minDist = 0.0f;
    public float maxDist = 4.0f;
    public float smooth = 10.0f;
    Vector3 Dollydir;
    public Vector3 dollyDirAdjusted;
    public float distance;

    
    
    
    // Use this for initialization
	void Awake ()
    {
        Dollydir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 desiredCamPos = transform.parent.TransformPoint(Dollydir * distance);
        RaycastHit hit;

        if (Physics.Linecast (transform.parent.position, desiredCamPos,out hit))
        {
            distance = Mathf.Clamp((hit.distance*0.9f), minDist, maxDist);
        }
        else
        {
            distance = maxDist;
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, Dollydir * distance, Time.deltaTime * smooth);
	}

}
