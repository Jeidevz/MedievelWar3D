using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationaCommand : MonoBehaviour {

    public Animator animator;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("space"))
        {
            print("space key was pressed");
            animator.Play("Walk");
        }
        else if (Input.GetKey(KeyCode.D))
        {

            animator.Play("Jump Attack");
        }
        else if (Input.GetKey(KeyCode.S))
        {

            animator.Play("180");
        }
        else
        {
        }

    }
}
