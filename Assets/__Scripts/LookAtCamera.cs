using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {
    public GameObject target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate()
    {
        //transform.LookAt(target.transform);
        transform.LookAt(target.transform);
        Vector3 relativePos = (target.transform.position + new Vector3(0, 0, -1.5f));
        transform.position = relativePos;


        transform.rotation = target.transform.rotation;
    }
}
