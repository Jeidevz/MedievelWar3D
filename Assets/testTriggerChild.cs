using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testTriggerChild : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        print("Enter");
    }

    private void OnTriggerStay(Collider other)
    {

        print("Stay");
    }

    private void OnTriggerExit(Collider other)
    {
        print("Exit");
    }
}
