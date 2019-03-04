using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatcamera : MonoBehaviour {


    public GameObject Target;

    void LateUpdate ()
    {
        transform.LookAt(Target.transform);
    }
}
