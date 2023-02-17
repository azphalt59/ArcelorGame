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

    public void AddItem(Item item)
    {
        Debug.Log("Ajoute " + item.name + "à l'inventaire du joueur");
        ItemDisplay inventoryItem = new ItemDisplay();
        inventoryItem.itemCount = 1;
        inventoryItem.itemSprite = item.gameObject.GetComponent<SpriteRenderer>().sprite;
        inventory.Add(inventoryItem);
        
    }
}
