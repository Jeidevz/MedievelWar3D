using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowmanMovementController : HumanoidController {

    float turnSmoothVelocity;
    Transform cameraTransform;
    float turnSpeedSmoothTime = 0.1f;
    Transform chest;
    protected new void Awake()
    {
        base.Awake();
        
        cameraTransform = Camera.main.transform; 
    }
    // Update is called once per frame
    void Update () {
        movementSetUp();
	}

    public void movementSetUp()
    {
        if (character.getIsAlive())
        {
            float vertical = Input.GetAxis(Constants.KeyInputs.VERTICAL);
            float horizontal = Input.GetAxis(Constants.KeyInputs.HORIZONTAL);


            animator.SetFloat(Constants.AnimatorParameters.VELOCITY_FLOAT, vertical);
            animator.SetFloat(Constants.AnimatorParameters.ROTATION_FLOAT, horizontal);
            animator.SetBool(Constants.AnimatorParameters.WALKING_BOOL, true);

            if (vertical == 0f && horizontal == 0f)
            {
                animator.SetBool(Constants.AnimatorParameters.WALKING_BOOL, false);

            }

            rotateWithCamera(vertical, horizontal);
        }


    }

    public void rotateWithCamera(float vertical, float horizontal)
    {
        Vector2 movements = new Vector2(vertical, horizontal);
        if (movements != Vector2.zero)
        {
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, cameraTransform.eulerAngles.y, ref turnSmoothVelocity, turnSpeedSmoothTime);
        }
    }

    public void chestBoneFollowCameraVericalMovement()
    {
        chest = animator.GetBoneTransform(HumanBodyBones.Chest);
        chest.rotation = new Quaternion(cameraTransform.rotation.x, chest.rotation.y, chest.rotation.z, chest.rotation.w);
    }


}
