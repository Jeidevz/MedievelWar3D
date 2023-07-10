using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearsSystem : MonoBehaviour {
    public GameObject primary;
    public GameObject secondary;
    protected float totalAttack;
    protected float totalStrength;
    protected float totalVitality;
    private Dictionary<Enums.Gears, GameObject> gearsDiction;


    private void Awake()
    {
        gearsDiction = new Dictionary<Enums.Gears, GameObject>();
        addGear(Enums.Gears.Primary, null);
        addGear(Enums.Gears.Secondary, null);
    }

    private void Start()
    {

    }

    public void updateAllGearSlots()
    {
        updateGearSlot(Enums.Gears.Primary, primary);
        updateGearSlot(Enums.Gears.Secondary, secondary);
    }

    public void updateGearSlot(Enums.Gears slot, GameObject gear)
    {
        gearsDiction[slot] = gear;
    }

    public void addGear(Enums.Gears slot, GameObject gear)
    {
        gearsDiction.Add(slot, gear);
    }

    public void updateGearsTotalStats()
    {
        if(gearsDiction.Count != 0)
        {
            allTotalStatsToZero();
            foreach (GameObject gear in gearsDiction.Values)
            {
                GearStats gearStats = gear.GetComponent<GearStats>();
                totalAttack += gearStats.attack;
                totalStrength += gearStats.strength;
                totalVitality += gearStats.vitality;
            }
        }
    }

    private void allTotalStatsToZero()
    {
        totalAttack = 0f;
        totalStrength = 0f;
    }

    public float getTotalAttack()
    {
        return totalAttack;
    }

    public float getTotalStrength()
    {
        return totalStrength;
    }

    public float getTotalVitality()
    {
        return totalVitality;
    }
}
