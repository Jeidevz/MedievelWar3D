using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator), typeof(AudioSource))]
public class PlayerHumanoidController : HumanoidController {

    [Header("Human")]
    public float turnSpeedSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    private Transform cameraTransform;

    new protected void Awake()
    {
        base.Awake();
        action = Enums.AnimationActions.Idling;
    }
    new protected void Start () {
        base.Start();
        cameraTransform = Camera.main.transform;
    }
	
	// Update is called once per frame
	void Update () {
        movementSetUp();
        playerCombatSetUp();
        godModeListener();

        if (!character.getIsAlive() && !deathExecuted)
        {
            deathProcess();
            deathExecuted = true;
        }
	}

    

    public void movementSetUp()
    {
        if (character.getIsAlive())
        {
            float vertical = Input.GetAxis(Constants.KeyInputs.VERTICAL);
            float horizontal = Input.GetAxis(Constants.KeyInputs.HORIZONTAL);

            animator.SetFloat(Constants.AnimatorParameters.VELOCITY_FLOAT, vertical);
            animator.SetFloat(Constants.AnimatorParameters.ROTATION_FLOAT, horizontal);

            rotateWithCamera(vertical, horizontal);
            kinematicWhenNotMoving(vertical, horizontal); //testing to disable being pushed
        }

        
    }

    public void rotateWithCamera(float vertical, float horizontal)
    {
        Vector2 movements = new Vector2(vertical, horizontal);
        if(movements != Vector2.zero)
        {
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, cameraTransform.eulerAngles.y, ref turnSmoothVelocity, turnSpeedSmoothTime);
        }
    }

    public void playerCombatSetUp()
    {
        playerAttackListener();
    }

    public void playerAttackListener()
    {
        if (Input.GetButton(Constants.KeyInputs.LEFT_MOUSE_CLICK))
        {
            attack();
        }
        else{
            cancelAttack();
        }
        
    }

    //game testing
    public void godModeListener()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            animator.speed = 3;
        else
            animator.speed = 1;
    }

    public void kinematicWhenNotMoving(float vertical, float horizontal)
    {
        Vector2 movement = new Vector2(vertical, horizontal);
        if(movement == Vector2.zero)
        {
            rigidB.isKinematic = true;
            action = Enums.AnimationActions.NotMoving;
        }
        else
        {
            rigidB.isKinematic = false;
            action = Enums.AnimationActions.Moving;
        }
    }


    


}
