using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {
    // Use this for initialization
    public float speedX, speedY;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speedX;
        float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speedY;

        transform.position += new Vector3(x, z);


    }

    private void FixedUpdate()
    {
    }
}
