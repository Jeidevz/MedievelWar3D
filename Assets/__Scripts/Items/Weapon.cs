using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Equipment {

    [SerializeField]
    protected Character character;
    protected BoxCollider attackBoxCollider;
    protected Enums.WeaponRangeTypes rangeType;
    [Header("Combat")]
    [SerializeField]
    protected bool doDamageOnHit;

    new protected void Awake()
    {
        base.Awake();
        attackBoxCollider = GetComponent<BoxCollider>();
    }

    protected new void Start()
    {
        base.Start();
        if (transform.parent)
        {
            owner = transform.parent.GetComponent<Holder>().getOwner();
            if (owner)
            {
                character = owner.GetComponent<Character>();
                isLootAble = false;
            }
        }
    }

    public void instantiateHitEffectThenDestoy(Vector3 position, GameObject effectObject, float duration)
    {
        GameObject effect = Instantiate(effectObject, position + new Vector3(0,transform.position.y , 0), Quaternion.identity);
        Destroy(effect, duration);
    }

    public virtual void weaponCanHit()
    {
        doDamageOnHit = true;
    }

    public virtual void weaponCannotHit()
    {
        doDamageOnHit = false;

    }

}
