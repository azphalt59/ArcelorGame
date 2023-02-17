using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : Interactible, ISpeakable
{
    private Sprite npcSprite;
    private string npcName;
    [SerializeField] private string[] npcDialog;
    public void Speak()
    {
        DialogManager.Instance.OpenDialog(npcSprite, GetComponent<SpriteRenderer>().color, npcName, npcDialog);
    }


    // Start is called before the first frame update
    void Start()
    {
        npcSprite = GetComponent<SpriteRenderer>().sprite;
        npcName = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Interaction()
    {
        Speak();
    }
}
