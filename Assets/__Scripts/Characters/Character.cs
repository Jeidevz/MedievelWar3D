using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Character : MonoBehaviour {
    protected CharacterStats charStats;
    protected GearsSystem gears;

    [Header("Current stats")]
    public float health;
    public float attack; 
    [SerializeField]
    protected bool isAlive = true;

    protected virtual void Awake()
    {
        


    }
    protected virtual void Start()
    {
        updateCharacterStats();
    }

    public void updateCharacterStats()
    {

        charStats = GetComponent<CharacterStats>();
        gears = GetComponent<GearsSystem>();
        health = charStats.baseHealth + (charStats.vitality + gears.getTotalVitality()) * Constants.StatsMultiplier.VITALITY;
        attack = (charStats.strength + gears.getTotalStrength()) * Constants.StatsMultiplier.STRENGTH + gears.getTotalAttack();
    }

    public Character() { }

    public bool isCharacterAlive()
    {
        if(health > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool getIsAlive()
    {
        return isAlive;
    }

    public void takeDamage(float damage)
    {
        if (health > 0)
        {
            health -= damage;
            if (health <= 0)
            {
                health = 0;
                isAlive = false;
            }
        }

        //print(name + " took " + damage + " dmg");
    }

    public void recoverHealth(int recoverAmount)
    {
        health += recoverAmount;
        if(health > 100)
        {
            health = 100;
        }
    }
    
    
}
