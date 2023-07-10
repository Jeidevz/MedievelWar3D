using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator), typeof(AudioSource), typeof(NavMeshAgent))]
public class AIHumanoidController : HumanoidController {
    public NavMeshAgent navMeshAgent;
    public float attackRange = 2.5f;
    public Transform navTargetTransform;
    public bool inRange;

    public float waitUntilChase = 2f;
    private float timer = 0;

    private SpawnerController spawnerController;

    new protected void Awake()
    {
        base.Awake();
        navMeshAgent.updatePosition = false;
    }
    // Use this for initialization
    protected new void Start () {
        base.Start();
        spawnerController = GameObject.FindGameObjectWithTag(Constants.SCENE_CONTROLLER_TAG).GetComponent<SpawnerController>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        timer += Time.deltaTime;
        navTargetTransform = findClosestAliveEnemyCharacterTransform(); //test

        AImovements();

        if (!character.getIsAlive() && !deathExecuted)
        {
            deathProcess();
            stopAI();
            navMeshAgent.enabled = false;
            deathExecuted = true;
        }


        if (navTargetTransform)
        {
            Debug.DrawLine(transform.position, navTargetTransform.position, Color.red);
        }
        godModeForTesting(); //Testing
    }

    void AImovements()
    {
        if (navTargetTransform)
        {

            float distance = Vector3.Distance(transform.position, navTargetTransform.position);
            chaseTarget(navTargetTransform);
            if (inRange && distance > attackRange + 1f)
            {
                inRange = false;
            }
            if (distance <= attackRange || inRange)
            {
                if (timer >= waitUntilChase)
                {
                    inRange = true;
                    
                    //print("remaining distance " + navMeshAgent.remainingDistance);
                    navMeshAgent.isStopped = true;

                    navAgentLookAtTarget();


                    animator.SetFloat(Constants.AnimatorParameters.VELOCITY_FLOAT, 0f);
                    rigidB.isKinematic = true; // test to disable push
                    attack();
                }
            }
            else
            {
                navMeshAgent.isStopped = false;
                animator.SetFloat(Constants.AnimatorParameters.VELOCITY_FLOAT, 1f);
                rigidB.isKinematic = false; // test to disable push
            }
        }
        else
        {
            stopAI();
        }


    }

    private void navAgentLookAtTarget()
    {
        //transform.LookAt(navTargetTransform);
        Vector3 pos = navTargetTransform.position - transform.position;
        Quaternion newRot = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRot, 1f * Time.deltaTime); //smooth turning to face the target
    }

    public void stopAI()
    {
        navMeshAgent.isStopped = true;
        animator.SetFloat(Constants.AnimatorParameters.VELOCITY_FLOAT, 0f);
        //rigidB.isKinematic = true; // test to disable push
        cancelAttack();
        if (!character.getIsAlive())
        {
            enabled = false;
        }
    }
    

    void chaseTarget(Transform target)
    {
        navMeshAgent.nextPosition = transform.position;
        navMeshAgent.SetDestination(target.position);
        if(navMeshAgent.nextPosition != transform.position)
        {
            //print("position fix");
            transform.position = navMeshAgent.nextPosition;
        }
        //transform.LookAt(navMeshAgent.nextPosition);
    }
    
    public Transform findClosestAliveEnemyCharacterTransform()
    {
        float closestDistance = float.MaxValue;
        Transform closestTransform = null;
        foreach (Transform colorObject in spawnerController.teamColors)
        {
            //print(colorObject.name);
            if(colorObject.name != tag)
            {
                foreach(Transform child in colorObject.transform)
                {
                    Character character = child.GetComponent<Character>();
                    if (character.getIsAlive())
                    {
                        float distance = Vector3.Distance(transform.position, child.position);
                        if(distance < closestDistance)
                        {
                            closestDistance = distance;
                            closestTransform = child;

                        }
                    }
                }
            }
        }

        return closestTransform;
    }

    public void settingUpJob()
    {

    }
    
    void godModeForTesting()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            animator.speed = 5;
        }
        else
        {
            animator.speed = 1;
        }
    }
    
   
}
