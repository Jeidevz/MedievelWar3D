using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetBehaviour : MonoBehaviour {
    public Transform target;
    public Transform floor;
    public float distanceFromFloor = 2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(target.position.x, floor.position.y + distanceFromFloor, target.position.z);
	}
}
