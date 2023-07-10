/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIControls : Controller {
    public Enemy enemy;
    public NavMeshAgent agent;

    private Transform target;
    private bool deathExecuted;

	// Use this for initialization
	void Start () {
        deathExecuted = false;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        //print("target pos: " + target.position);
	}
	
	// Update is called once per frame
	void Update () {
        if(!enemy.isCharacterAlive() && !deathExecuted)
        {
            killEnemy();
            deathExecuted = true;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<BoxCollider>().enabled = false;
        }

        if (enemy.isCharacterAlive())
        {
            chaseTarget();
        }
	}

    

    void killEnemy()
    {
        int value = Random.Range(1, 3);
        animator.SetInteger("Death", value);
        animator.SetTrigger("DeathTrigger");
        animator.SetBool("isAlive", false);
        GetComponent<NavMeshAgent>().enabled = false;
        
    }

    void chaseTarget()
    {
        //print(agent.remainingDistance);
        agent.SetDestination(target.position);
        if (agent.remainingDistance < 3)
        {
            animator.SetFloat("Velocity", 0);
            animator.SetBool("AttackBool", true);
            agent.isStopped = true;

        }
        else
        {

            animator.SetFloat("Velocity", 1);
            animator.SetBool("AttackBool", false);
            agent.isStopped = false;
        }
    }
}
*/