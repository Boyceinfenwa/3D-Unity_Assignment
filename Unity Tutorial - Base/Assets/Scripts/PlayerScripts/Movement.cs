using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public AudioClip shoutingClip;
    public float speedDamptime = 0.0f;
    public float xSensitivity = 1.0f;

    private Animator anim;
    private HashIDs hash;

    private float elapsedTime = 0.0f;
    private bool nobackmov = false;


    private void Awake()
    {
        anim = GetComponent<Animator> () ;
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();
        anim.SetLayerWeight(1, 1f);
    }

    private void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");
        bool sneak = Input.GetButton("Sneak");
        float mouseX = Input.GetAxis("MouseX");

        Rotating(mouseX);
        MovementManager(v, sneak);

        elapsedTime += Time.deltaTime;
        Debug.Log("elapsed time is : " + elapsedTime);

    }

    void Update()
    {
        bool shout = Input.GetButtonDown("Attract");
        anim.SetBool(hash.shoutingBool, shout);
        AudioManagement(shout);
    }

    void MovementManager(float Vertical, bool sneaking)
    {
        anim.SetBool(hash.sneakingBool, sneaking);

        if (Vertical > 0)
        {
            anim.SetFloat(hash.speedFloat, 1.5f, speedDamptime, Time.deltaTime);
            anim.SetBool("Backwards",false);
            nobackmov = true;
        }
        if (Vertical < 0)
        {
            anim.SetFloat(hash.speedFloat, -1.5f, speedDamptime, Time.deltaTime);
            anim.SetBool("Backwards",true);

            Rigidbody ourBody = this.GetComponent<Rigidbody> ();

            float movement = Mathf.Lerp(0f, -0.025f, elapsedTime);
            Vector3 moveBack = new Vector3 (0.0f, 0.0f, movement);
            moveBack = ourBody.transform.TransformDirection(moveBack);
            ourBody.transform.position += moveBack;

            if (nobackmov == true)
            {
                elapsedTime = 0;
                nobackmov = false;
            }
        }

        if (Vertical == 0)
        {
            anim.SetFloat(hash.speedFloat, 0.01f);
            anim.SetBool("Backwards",false);
            nobackmov = true;
        }

        if (Input.GetKey (KeyCode.LeftControl))

        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }

    void Rotating (float mouseXInput)
    {
        Rigidbody ourBody = this.GetComponent<Rigidbody>();

        if (mouseXInput != 0)
        {
            Quaternion deltaRotation = Quaternion.Euler(0f, mouseXInput * xSensitivity, 0f);

            ourBody.MoveRotation(ourBody.rotation * deltaRotation);
        }
    }

    void AudioManagement (bool shout)
    {
        if (anim.GetCurrentAnimatorStateInfo (0).IsName("Walk"))
        {
            if (!anim.GetComponent<AudioSource> ().isPlaying)
            {
                GetComponent<AudioSource>().pitch = 0.27f;
                GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            GetComponent<AudioSource>().Stop();
        }

        if (shout)
        {
            AudioSource.PlayClipAtPoint(shoutingClip, transform.position);
        }
    }
}
