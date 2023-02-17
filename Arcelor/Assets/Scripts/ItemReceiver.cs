using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemReceiver : Interactible
{
    [SerializeField] private ItemDisplay itemNeeded;
    [SerializeField] private int itemCountNeeded;
    [SerializeField] private SpriteRenderer itemSprite;

    [SerializeField] private GameObject door;

    private void Start()
    {
        itemNeeded.itemSprite = itemSprite.sprite;
    }
    public override void Interaction()
    {
        foreach(ItemDisplay item in PlayerInventory.Instance.GetInventory())
        {
            if(item.itemSprite == itemNeeded.itemSprite)
            {
                if (item.itemCount >= itemCountNeeded)
                {
                    door.SetActive(false);
                    PlayerInventory.Instance.RemoveItem(itemNeeded, itemCountNeeded);
                }
             
            }
        }
    }
}
