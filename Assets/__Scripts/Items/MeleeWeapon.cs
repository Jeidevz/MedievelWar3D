using UnityEngine;

public class MeleeWeapon : Weapon
{
    

    protected new void Awake()
    {
        base.Awake();
        rangeType = Enums.WeaponRangeTypes.Melee;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        doDamageToCharacterLayer(other);
    }

    public void doDamageToCharacterLayer(Collider other)
    {
        if (doDamageOnHit)
        {
            /*print(owner.name + " hit other " + other.name +
                "\n weapon damageable: " + doDamageOnHit);*/
            if (other.gameObject.layer == LayerMask.NameToLayer(Constants.Layers.CHARACTER))
            {
                if (other.gameObject.tag != owner.tag)
                {
                    if (isOtherCharacterAlive(other))
                    {
                        getOthersCharacterComponent(other).takeDamage(character.attack);
                        otherLightHitTrigger(other);
                    }
                }
            }
        }
    }

    public void otherLightHitTrigger(Collider other)
    {
        Animator animator = other.GetComponent<Animator>();
        animator.SetTrigger(Constants.AnimatorParameters.GET_LIGHT_HIT_TRIGGER);
    }

    public Character getOthersCharacterComponent(Collider other)
    {
        Character otherCharacter = other.gameObject.GetComponent<Character>();
        return otherCharacter;
    }

    public bool isOtherCharacterAlive(Collider other)
    {
        Character otherCharacter = other.gameObject.GetComponent<Character>();
        return otherCharacter.getIsAlive();

    }



}