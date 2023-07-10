using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementAdvanced {
    /*
    public float speed;
    public float rotateSpeed;
    public Text HpUiText;
    public Player player;
    public GameObject weaponHolder;
    public float turnSpeedSmoothTime = 0.1f;

    float turnSmoothVelocity;
    Rigidbody rg;
    bool isAlive;
    Transform cameraTransform;


    // Use this for initialization
    void Start () {
        rg = gameObject.GetComponent<Rigidbody>();
        HpUiText.text = "Health: " + player.health;
        isAlive = true;

        cameraTransform = Camera.main.transform;
    }
	
	// Update is called once per frame
	void Update () {

        HpUiText.text = "Health: " + player.health;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }

        if (Input.GetButtonDown("Fire1"))
            animator.SetBool("AttackBool", true);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.speed = 2;
        }
        else
        {
            animator.speed = 1;
        }

        if (!isPlayerAlive() && isAlive)
        {
            playerDieSetUp();
            isAlive = false;
        }

        playerHPDecreasTest();
        if (Input.GetKeyDown(KeyCode.R))
        {
            revivePlayer();
        }

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, cameraTransform.eulerAngles.y, ref turnSmoothVelocity, turnSpeedSmoothTime);
        }
        
    }

    private void FixedUpdate()
    {
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rg.AddForce(transform.up * 300);
        }

        animator.SetFloat("Velocity", vert);
        animator.SetFloat("Rotation", hori);

        if (vert > .1f || vert < -.1f)
        {
            
            //print("moving vert");
            if (hori > .1f)
            {
                //Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, rotateSpeed, 0) * Time.deltaTime);
                //rg.MoveRotation(rg.rotation * deltaRotation);

                //rotateRigidBody(rg, rotateSpeed);
            }
            else if(hori < -.1f)
            {
                //Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, -rotateSpeed, 0) * Time.deltaTime);
                //rg.MoveRotation(rg.rotation * deltaRotation);
                //rotateRigidBody(rg, -rotateSpeed);
            }
        }

    }

    void rotateRigidBody(Rigidbody rb, float speed)
    {
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, speed, 0) * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    

    private bool isPlayerAlive()
    {
        if(player.health > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void playerDieSetUp()
    {
        audioSource.PlayOneShot(dieSound);
        int value = Random.Range(1, 3);
        animator.SetInteger("Death", value);
        animator.SetTrigger("DeathTrigger");
        animator.SetBool("isAlive", false);
        weaponIsActive(false);

    }

    void resetDeathValueToZero()
    {
        animator.SetInteger("Death", 0);
    }

    void weaponIsActive(bool state)
    {
        BoxCollider boxCollider = weaponHolder.GetComponentInChildren<BoxCollider>();
        print(boxCollider);
        boxCollider.enabled = state;
    }

    void playerHPDecreasTest()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            int damage = 20;
            player.takeDamage(damage);
        }
    }

    void revivePlayer()
    {
        animator.SetTrigger("ReviveTrigger");
        player.health = 100;
        isAlive = true;
        animator.SetBool("isAlive", true);
        weaponIsActive(true);
    }

    

    

    /*
     *Gizmos draw graphics for debugging
    void OnDrawGizmosSelected()
    {
        if (go.transform != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(new Vector3(100,100,100), go.transform.position);
        }
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(go.transform.position, go.transform.position + transform.forward * 20);
        print("n:" + go.transform.position);
        print("local:" + go.transform.localPosition);
        print("f:" + transform.forward);

    }
    */
    
}
