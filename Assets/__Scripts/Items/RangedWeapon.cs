using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon {
    [Header("Effect")]
    public AudioClip shootSound;
    public GameObject shootEffect;

    protected new void Awake()
    {
        base.Awake();
        rangeType = Enums.WeaponRangeTypes.Ranged;
    }
}
