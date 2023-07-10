using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Controller : MonoBehaviour {

    [SerializeField]
    protected Animator animator; 
    [SerializeField]
    protected Rigidbody rigidB;
    protected bool deathExecuted;
    protected Enums.AnimationActions action;

    virtual protected void Awake()
    {
        animator = GetComponent<Animator>();
        rigidB = GetComponent<Rigidbody>();
    }

    virtual protected void Start()
    {

    }

    public Enums.AnimationActions getCurrentAction()
    {
        return action;
    }

    public void move(Vector3 destination)
    {
        
    }

    



}
