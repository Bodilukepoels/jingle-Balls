using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    // The name of the item
    public string name;

    // The number of the item that the player has
    public int quantity;

    // The sprite to display for the item
    public Sprite sprite;

    // A flag to indicate if the item is stackable
    public bool isStackable;

    // The maximum stack size for the item
    public int maxStackSize;

    // A constructor to create an item with a given name, quantity, and sprite
     public Item(string name, int quantity, Sprite sprite, bool isStackable, int maxStackSize)
    {
        this.name = name;
        this.quantity = quantity;
        this.sprite = sprite;
        this.isStackable = isStackable;
        this.maxStackSize = maxStackSize;
    }

    // A constructor to create an item with a given name, quantity, and sprite
    public Item(string name, int quantity, Sprite sprite, bool isStackable)
    {
        this.name = name;
        this.quantity = quantity;
        this.sprite = sprite;
        this.isStackable = isStackable;
    }
}

public class Recipe
{
    // The required materials for the recipe
    public Item material1;
    public Item material2;

    // The item that is crafted using the recipe
    public Item craftedItem;
}
public class InventoryController : MonoBehaviour
{
    // A reference to the inventory UI panel
    public GameObject inventoryPanel;

    // A list of all the items in the inventory
    public List<Item> inventory = new List<Item>();

    // The currently selected item
    public Item selectedItem;

    void Update()
    {
        // If the player presses the "TAB" key
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Toggle the inventory panel
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
    }

    // A function to add an item to the inventory
    public void AddItem(Item item)
    {
        // Add the item to the inventory
        inventory.Add(item);
    }

    // A function to remove an item from the inventory
    public void RemoveItem(Item item)
    {
        // Remove the item from the inventory
        inventory.Remove(item);
    }

    // A function to craft an item using the materials in the inventory
    public void CraftItem(Recipe recipe)
    {
        // Check if the inventory has all the materials required for the recipe
        if (inventory.Contains(recipe.material1) && inventory.Contains(recipe.material2))
        {
            // Remove the materials from the inventory
            inventory.Remove(recipe.material1);
            inventory.Remove(recipe.material2);

            // Add the crafted item to the inventory
            inventory.Add(recipe.craftedItem);
        }
    }
}

public class Inventory
{
    // A list of all the items in the inventory
    public List<Item> items = new List<Item>();

    // A function to add an item to the inventory
    public void AddItem(Item item)
    {
        // Check if the item is stackable
        if (item.isStackable)
        {
            // Check if the item is already in the inventory
            bool itemExists = false;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].name == item.name)
                {
                    // If the item is already in the inventory, increase the stack size
                    items[i].maxStackSize++;
                    itemExists = true;
                    break;
                }
            }

            // If the item is not in the inventory, add it to the list
            if (!itemExists)
            {
                items.Add(item);
            }
        }
        // If the item is not stackable, add it to the list
        else
        {
            items.Add(item);
        }
    }
    
}