using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CraftingSystem craftingSystem = new CraftingSystem();
        Item sword = craftingSystem.AvailableItems[0];
        craftingSystem.CraftItem(sword);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
