using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Interactible interactible;

    private void Update()
    {
        if(interactible != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Interaction();
            }
        }
       
    }
    
    public void SetInteractible(GameObject gameObject)
    {
        interactible = gameObject.GetComponent<Interactible>();
    }
    public void ResetInteractible()
    {
        interactible = null;
    }
    public void Interaction()
    {
        interactible.Interaction();
    }
}
