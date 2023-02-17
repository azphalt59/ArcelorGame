using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemDisplay
{
    public int itemCount;
    public Sprite itemSprite;
}
public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;
    [SerializeField] private List<ItemDisplay> inventory;
    

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }
    public List<ItemDisplay> GetInventory()
    {
        return inventory;
    }
    public void AddItem(Item item)
    {
        // Create new inventory Item
        ItemDisplay inventoryItem = new ItemDisplay();
        inventoryItem.itemCount = 1;
        inventoryItem.itemSprite = item.gameObject.GetComponent<SpriteRenderer>().sprite;

        ManageItem(inventoryItem);
    }
    public void RemoveItem(ItemDisplay inventoryItem, int count)
    {
        int goodIndex = 0;
        for (int i = 0; i < inventory.Count; i++)
        {
            if(inventory[i] == inventoryItem)
            {
                goodIndex = i;
                return;
            }

        }
        inventory[goodIndex].itemCount -= count;
        
        if (inventory[goodIndex].itemCount <= 0) inventory.Remove(inventoryItem);
    }

    void ManageItem(ItemDisplay inventoryItem)
    {
        foreach (ItemDisplay invItem in inventory)
        {
            if (inventoryItem.itemSprite == invItem.itemSprite)
            {
                invItem.itemCount++;
                return;
            }
        }
        inventory.Add(inventoryItem);
    }
}
