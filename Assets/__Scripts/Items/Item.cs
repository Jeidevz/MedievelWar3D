using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour {

    public bool isLootAble;
    public AudioClip lootSound;

    public AudioSource audioSource; //protected
    [SerializeField]
    protected GameObject owner; //protected - public for testing

    protected virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    protected virtual void Start()
    {
        Holder holder = GetComponentInParent<Holder>();
        if (holder)
        {
            owner = holder.getOwner();
        }
        //print(root);
    }

    public string getCurrentOwnerTag()
    {
        if (owner != null)
        {
            return owner.tag;
        }
        else
        {
            return "There no owner.";
        }
        
    }

    public bool haveOwner()
    {
        if (owner)
        {
            return true;
        }
        return false;

    }

    public string getCurrentOwnerName()
    {
        if (owner != null)
        {
            return owner.name;
        }
        return "There no owner.";
        
    }

    public GameObject getHolderOwner()
    {
        return owner;
    }

    public int getCurrentOwnerID()
    {
        return owner.GetInstanceID();
    }
}
