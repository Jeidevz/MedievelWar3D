using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveItem : MonoBehaviour {

    public Text text;
    public string textContent;

    public Item item; //private - public for testing
    private void Awake()
    {
        item = GetComponent<Item>();
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
