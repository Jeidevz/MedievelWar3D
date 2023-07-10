using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour {
    public GameObject holderOwner;
    public bool holderPrimaryWeapon;

    public GameObject holderWeapon; //private - public for testing

    private void Start()
    {
        updateCurrentWeapon();
        GearsSystem ownerEquipSystem = holderOwner.GetComponent<GearsSystem>();
        if (ownerEquipSystem)
        {
            if (holderPrimaryWeapon)
            {
                ownerEquipSystem.primary = holderWeapon;
                ownerEquipSystem.updateGearSlot(Enums.Gears.Primary, holderWeapon);
            }
            else
            {
                ownerEquipSystem.secondary = holderWeapon;
                ownerEquipSystem.updateGearSlot(Enums.Gears.Secondary, holderWeapon);
            }
        }
    }

    public void updateCurrentWeapon()
    {
        if (transform.childCount > 0)
        {
            holderWeapon = transform.GetChild(0).gameObject;

        }
        else
        {
            holderWeapon = null;
        }
    }

    public GameObject getCurrentWeapon()
    {
        return holderWeapon;
    }

    public void setNewWeapon(GameObject weapon)
    {
        holderWeapon = weapon;
    }

    public GameObject getOwner()
    {
        return holderOwner;
    }
}
