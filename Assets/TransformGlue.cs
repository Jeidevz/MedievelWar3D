using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TransformGlue : MonoBehaviour {
    public Transform glueTarget;
	// Use this for initialization
	void Start () {
        transform.parent = glueTarget;
    }
	
	// Update is called once per frame
	void Update () {
	}
}
