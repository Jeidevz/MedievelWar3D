using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showScriptableObjectTest : MonoBehaviour {

    public scriptableObjectTest test;
    public int value;
	// Use this for initialization
	void Start () {
        value = test.value;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.DownArrow))
            test.value--;
	}
}
