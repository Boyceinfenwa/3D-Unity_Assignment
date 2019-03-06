using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCamfollow : MonoBehaviour {


    public float Camspeed = 120.0f;
    public GameObject CameraFollowObj;
    Vector3 Followpos;
    public float ClampAngle = 80.0f;
    public float InputSensitivity = 150.0f;
    public GameObject CameraObj;
    public GameObject PlayerObj;
    public float CamdistanceX;
    public float CamdistanceY;
    public float CamdistanceZ;
    public float mouseX;
    public float mouseY;
    public float FinalInputX;
    public float FinalInputY;
    public float FinalInputZ;


    public float SmoothX;
    public float SmoothY;

    private float RotX = 0.0f;
    private float RotY = 0.0f;


    // Use this for initialization
    void Start ()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        RotX = rot.x;
        RotY = rot.y;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float Inputx = Input.GetAxis("RightStickHorizontal");
        float Inputz = Input.GetAxis("RightStickVertical");

        mouseX = Input.GetAxis("MouseX");
        mouseY = Input.GetAxis("MouseY");
        FinalInputX = Inputx + mouseX;
        FinalInputZ = Inputz + mouseY;

        RotY += FinalInputX * InputSensitivity * Time.deltaTime;
        RotX += FinalInputZ * InputSensitivity * Time.deltaTime;

        RotX = Mathf.Clamp(RotX, -ClampAngle, ClampAngle);

        Quaternion localRotation = Quaternion.Euler(RotX, RotY, 0.0f);
        transform.rotation = localRotation;

    }

    void LateUpdate()
    {
        CamUpdater();
    }

    void CamUpdater()
    {
        Transform target = CameraFollowObj.transform;

        float step = Camspeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);




    }
}
