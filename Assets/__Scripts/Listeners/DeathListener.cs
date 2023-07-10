using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathListener : Listener {
    Character character;
    public bool isAlive = true;
	
	// Update is called once per frame
	void Start () {
        character = GetComponentInParent<Character>();
	}

    private void Update()
    {
        if(character.health <= 0 && isAlive)
        {
            deathProcess();
            isAlive = false;
        }
    }

    private void deathProcess()
    {
        Animator animator = GetComponentInParent<Animator>();
        animator.SetTrigger(Constants.AnimatorParameters.DEATH_TRIGGER);
    }
}
