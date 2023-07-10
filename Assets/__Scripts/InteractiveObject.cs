using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveObject : MonoBehaviour {
    public Item item;
    public float detectRadius;
    public string commandText;
    public Text textObject;
    public Vector3 equipPosition;
    public Vector3 equipRotation;

    public GameObject approachingPlayer;
    public GameObject weaponHolder;
    public bool equipped;

    private bool focused;

    private void Awake()
    {
        weaponHolder = getCurrentWeaponHolder();
    }
    // Use this for initialization
    void Start () {
	}

    // Update is called once per frame
    void Update()
    {
        if (focused)
        { 
            if (Input.GetKeyDown(KeyCode.E))
            {
                unEquipCurrentWeapon();
                equipWeapon();
            }
        }

		
	}

    /*
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        //print(name + " Enter: " + other.tag);
        if (other.tag == "Player" && !equipped && getWeaponOwnerTag() != "Enemy")
        {
            approachingPlayer = other.gameObject;
            //print("apphroaching player name: " + approachingPlayer.name);
            //weaponHolder = approachingPlayer.GetComponent<Player>().getPrimary();
            if (textObject)
            {
                textObject.text = commandText;
                textObject.enabled = true;
            }
            focused = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //print(name + " Exit: " + other.tag);
        if (other.tag == "Player" && getWeaponOwnerTag() != "Enemy")
        {
            approachingPlayer = null;
            if (textObject)
            {
                textObject.enabled = false;
            }
            focused = false;
        }
        if (!equipped)
        {
            weaponHolder = null;
        }
    }

    void unEquipCurrentWeapon()
    {
        
    }

    void equipWeapon()
    {
        
        
    }

    public GameObject getCurrentWeaponHolder()
    {
        if (transform.parent)
        {
            return transform.parent.gameObject;
        }
        else
        {
            return null;
        }
    }

    public string getWeaponOwnerTag()
    {
        Transform root = transform.root;
        if (root.GetInstanceID() != GetInstanceID())
        { 
            return transform.root.tag;
        }
        else
        {
            return "no owner";
        }
    }

    void ChangeItemOwner()
    {
        //GameObject  GetComponent<Weapon>().AssignItemOwner();
    }
    
}
