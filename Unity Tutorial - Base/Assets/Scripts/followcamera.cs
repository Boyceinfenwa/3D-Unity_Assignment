﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followcamera : MonoBehaviour {

    public GameObject target;
    Vector3 offset;
    public float smoothTime = 0.3F;
    private float yVelocity = 0.0F;
    private float mouseX;
    private float mouseY;
    private float mouseZ;
    


    // Use this for initialization
    void Start ()
    {
        offset = transform.position - target.transform.position;

	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        mouseX = Input.GetAxis("MouseX");
        mouseY = Input.GetAxis("Mouse Y");
        mouseZ = Input.GetAxis("Mouse ScrollWheel");

        if (Input.GetMouseButton(1))
        {
            offset = Quaternion.Euler(0, mouseX, 0) * offset;
        }

        float angleBetween = Vector3.Angle(Vector3.up, transform.forward);
        Debug.Log("offset Angle: " + angleBetween);

        if (Input.GetMouseButton(0))
        {
            Vector3 LocalRight = target.transform.worldToLocalMatrix.MultiplyVector(transform.right);
            offset = Quaternion.AngleAxis(mouseY, LocalRight) * offset;
        }
        float desiredAngle = target.transform.eulerAngles.y;
        float currentAngle = transform.eulerAngles.y;

        float angle = Mathf.SmoothDampAngle(currentAngle, desiredAngle, ref yVelocity,smoothTime);

        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        transform.position = target.transform.position + (rotation * offset);
        transform.LookAt (target.transform);

        
	}
}
