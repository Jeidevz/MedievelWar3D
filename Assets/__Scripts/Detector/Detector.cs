using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour {
    protected float detectRadius;
    protected SphereCollider detectCollider;
    [SerializeField]
    protected GameObject itemObject;

    protected virtual void Awake()
    {
        detectCollider = GetComponent<SphereCollider>();
        detectRadius = detectCollider.radius;
    }

    protected GameObject mostCloseObject(Dictionary<string,GameObject> diction)
    {
        float mostShortDistanceValue = 999f;
        foreach (KeyValuePair<string,GameObject> item in diction)
        {
            float distance = Vector3.Distance(transform.position, item.Value.transform.position);
            if(distance < mostShortDistanceValue)
            {
                itemObject = item.Value;
            }
        }

        return itemObject;
    }

    public GameObject getMostCloseItemObject()
    {
        return itemObject;
    }
}
