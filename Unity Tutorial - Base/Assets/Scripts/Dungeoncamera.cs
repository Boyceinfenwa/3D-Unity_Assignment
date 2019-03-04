using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeoncamera : MonoBehaviour {

    public GameObject target;
    Vector3 offset;

    void Start ()
    {
        offset = transform.position - target.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        Vector3 desiredPosition = target.transform.position + offset;
        transform.position = desiredPosition;
        transform.LookAt(target.transform.position);
	}
}
