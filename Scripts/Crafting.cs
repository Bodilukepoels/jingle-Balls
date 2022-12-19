using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
  
    public string Name { get; set; }
}

public class Item
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Material> Materials { get; set; }
    public int Cost { get; set; }
    public int Value { get; set; }
}

public class CraftingSystem
{
    public List<Item> AvailableItems { get; set; }
    public List<Material> Materials { get; set; }

    public void CraftItem(Item item)
    {
        // Check if the player has all of the required materials
        bool hasMaterials = true;
        foreach (Material material in item.Materials)
        {
            if (!HasMaterial(material))
            {
                hasMaterials = false;
                break;
            }
        }

        // If the player has all of the required materials, craft the item
        if (hasMaterials)
        {
            // Remove the materials from the player's inventory
            foreach (Material material in item.Materials)
            {
                RemoveMaterial(material);
            }

            // Add the crafted item to the player's inventory
            AddItem(item);
        }
    }

    public void AddMaterial(Material material)
    {
        Materials.Add(material);
    }

    public void RemoveMaterial(Material material)
    {
        Materials.Remove(material);
    }

    public bool HasMaterial(Material material)
    {
        return Materials.Contains(material);
    }

    public void AddItem(Item item)
    {
        // Add the item to the player's inventory
    }
}