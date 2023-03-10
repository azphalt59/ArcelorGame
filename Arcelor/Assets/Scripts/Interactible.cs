using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour, IInteractable
{
    public GameObject interactionInput;
    bool isInteractable = false;

   
    public void ShowInteraction()
    {
        isInteractable = !isInteractable;
        interactionInput.SetActive(isInteractable);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(gameObject.name  + " est interactible");
        other.GetComponent<PlayerInteraction>().SetInteractible(this.gameObject);
        ShowInteraction();
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log(gameObject.name + " n'est plus interactible");
        other.GetComponent<PlayerInteraction>().ResetInteractible();
        ShowInteraction();
    }

    public virtual void Interaction()
    {
        
    }
}
