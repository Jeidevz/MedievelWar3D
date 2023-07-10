using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMagnitude : MonoBehaviour {

    public AudioClip audioClip;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(audioClip);
        //print(name + "collision enter: " + collision.gameObject.name);
        printMagnitude(collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        //print(name + "collision exit: " + collision.gameObject.name);
        printMagnitude(collision);

    }

    private void OnCollisionStay(Collision collision)
    {
        //print(name + "collision stay: " + collision.gameObject.name);
        printMagnitude(collision);

    }

    void printMagnitude(Collision coll)
    {
        //print(coll.relativeVelocity.magnitude);
    }
}
