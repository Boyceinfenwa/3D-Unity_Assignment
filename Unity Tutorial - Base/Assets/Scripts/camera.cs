using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

    public GameObject target;

    void Awake()
    {
        this.transform.RotateAround(target.transform.position, Vector3.up, 90f);
        
    }
}
