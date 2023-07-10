using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetector : Detector {
    public Dictionary<string, GameObject> itemObjectDiction;

    protected override void Awake()
    {
        base.Awake();
        itemObjectDiction = new Dictionary<string, GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsColliderAnItem(other) && isItemLootable(other))
        {
            //print(other.name + " item detected!");

            string id =""+ other.gameObject.GetInstanceID();

            GameObject go = other.gameObject;
            itemObjectDiction.Add(id, go);

            //print("Enter String id: " + id + " go: " + go.name);

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (IsColliderAnItem(other) && isItemLootable(other))
        {
            GameObject mostCloseItem = mostCloseObject(itemObjectDiction);
            itemObject = mostCloseItem;
            //print("Closest item" + mostCloseItem);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (IsColliderAnItem(other) && isItemLootable(other))
        {
            string id = ""+other.gameObject.GetInstanceID();
            //print("Exit string ID: " + id);
            itemObjectDiction.Remove(id);

            //print("Diction count: " + itemObjectDiction.Count);
            if(itemObjectDiction.Count == 0)
            {
                itemObject = null;
            }
        }
    }

    public bool IsColliderAnItem(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer(Constants.Layers.ITEM))
        {
            return true;
        }
        return false;
    }

    public bool isItemLootable(Collider other)
    {
        Item item = other.GetComponent<Item>();
        if (item.isLootAble)
        {
            return true;
        }
        return false;
    }
}
