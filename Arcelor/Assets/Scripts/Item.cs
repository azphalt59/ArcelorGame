using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item : Interactible, IPickable
{
    public void Pick()
    {
        PlayerInventory.Instance.AddItem(this);
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    public override void Interaction()
    {
        Pick();
    }

    private void Update()
    {
        
    }
}
