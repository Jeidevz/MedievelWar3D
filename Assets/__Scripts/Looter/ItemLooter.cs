using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemLooter : Looter {
    public ItemDetector itemDetector;
    public Text interactText;

    private void Update()
    {
        if (itemDetector && interactText)
        {
            if (itemDetector.itemObjectDiction.Count != 0)
            {
                GameObject item = itemDetector.getMostCloseItemObject();
                if (item)
                {
                    interactText.text = "[E] Equip " + item.name;
                }
            }
            else
            {
                interactText.text = "";
            }
        }
    }
}
