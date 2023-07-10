using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TriggerAttack : MonoBehaviour {

    public Animator anim;
    public NavMeshAgent agent;

    private bool arrivedDestination;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        print(name + " trigger enter: " + other.tag);
        if (other.tag == "Player")
        {
            //agent.enabled = false;
            arrivedDestination = true;
            anim.SetBool("AttackBool", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print(name + " trigger exit: " + other.tag);
        if (other.tag == "Player")
        {
            //agent.enabled = true;
            agent.ResetPath();
            arrivedDestination = false;
            anim.SetBool("AttackBool", false);
        }
    }

    public bool isArrivedDestination()
    {
        return arrivedDestination;
    }
}
