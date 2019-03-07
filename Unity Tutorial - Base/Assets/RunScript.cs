using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunScript : StateMachineBehaviour {


    private Animator anim;
    private HashIDs hash;
    public float speedDamptime = 0.0f;
    public float xSensitivity = 1.0f;
    public float pace = 2.0f;
   
    private float elapsedTime = 0.0f;
    public float multiplyer = 3.8f;
    private GameObject player;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            elapsedTime = Time.deltaTime;


   
            Rigidbody ourBody = player.GetComponent<Rigidbody>();

            float movement = Mathf.Lerp(0f, pace, elapsedTime*multiplyer);
            Vector3 moveforward = new Vector3(0.0f, 0.0f, movement);
            moveforward = ourBody.transform.TransformDirection(moveforward);
            ourBody.transform.position += moveforward;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

    }
};

	