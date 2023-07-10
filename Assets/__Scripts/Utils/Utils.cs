using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour {

    public bool isTriggeredByWeapon(Collider other)
    {
        if (other.gameObject.tag == Constants.ObjectTags.WEAPON)
        {
            return true;
        }
        return false;
    }
}
