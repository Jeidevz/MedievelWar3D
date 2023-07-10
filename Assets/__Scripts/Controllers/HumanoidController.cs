using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidController : Controller {
    [SerializeField]
    protected Character character;

    [Header("Weapon")]
    public Holder[] holders;
    
    [SerializeField]
    protected GearsSystem equips;

    public float movementSpeed = 1;

    new protected void Awake()
    {
        base.Awake();
        character = GetComponent<Character>();
        equips = GetComponent<GearsSystem>();

    }

    protected new void Start()
    {
        base.Start();
    }


    

    public void attack()
    {
        animator.SetBool(Constants.AnimatorParameters.NORMAL_ATTACK_BOOL, true);
        action = Enums.AnimationActions.Attacking;
    }

    public void cancelAttack()
    {
        animator.SetBool(Constants.AnimatorParameters.NORMAL_ATTACK_BOOL, false);
        action = Enums.AnimationActions.NotAttacking;
    }

    public void deathProcess()
    {
        cancelAttack();
        rigidB.isKinematic = true;
        rigidB.useGravity = false;
        selectRandomDeathClipAndTrigger(2);
        animator.SetBool(Constants.AnimatorParameters.ALIVE_BOOL, false);
        stopMovements();
        GetComponent<CapsuleCollider>().enabled = false;
        transform.localPosition = new Vector3(transform.localPosition.x, 0, transform.localPosition.z);
        equips.primary.GetComponent<Weapon>().weaponCannotHit();
    }

    public void selectRandomDeathClipAndTrigger(int clipsAmount)
    {

        int value = Random.Range(1, clipsAmount + 1);
        animator.SetInteger(Constants.AnimatorParameters.DEATH_INT, value);
        animator.SetTrigger(Constants.AnimatorParameters.DEATH_TRIGGER);
    }

    public void stopMovements()
    {
        animator.SetFloat(Constants.AnimatorParameters.VELOCITY_FLOAT, 0f);
        animator.SetFloat(Constants.AnimatorParameters.ROTATION_FLOAT, 0f);
    }

    public Weapon getWeaponComponentFromCollider(Collider collider)
    {
        Weapon weapon = collider.gameObject.GetComponent<Weapon>();
        if (weapon)
        {
            return weapon;
        }

        return null;
    }
}
