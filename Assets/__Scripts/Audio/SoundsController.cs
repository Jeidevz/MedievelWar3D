using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SoundsController : MonoBehaviour {
    public AudioLibrary audioLibrary;
    protected AudioSource audioSource;

    protected virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
}
