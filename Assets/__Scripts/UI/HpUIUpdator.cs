using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpUIUpdator : TextUIValueUpdator {
    Character character;
    private void Start()
    {
        character = GetComponentInParent<Character>();
    }

    private void Update()
    {
        if (text)
        {
            text.text = "Health: " + character.health;
        }
    }
}
