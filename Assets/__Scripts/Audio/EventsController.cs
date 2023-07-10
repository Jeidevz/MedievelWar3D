using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventsController : MonoBehaviour {
    protected AudioSource audioSource;

    protected virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    

}
