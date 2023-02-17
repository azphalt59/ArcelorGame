using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class DialogSystem
{
    public Image SpeakerSprite;
    public TextMeshProUGUI SpeakerName;
    public TextMeshProUGUI DialogDisplay;
    public string[] SpeakerDialog;
    public int stringIndex;
}
public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;
    public DialogSystem DialogSyst;
    public PlayerMovement playerMovement;
    [SerializeField] private GameObject dialogCanvas;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }
    private void Update()
    {
        if (dialogCanvas.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                NextDialog();
            }
            playerMovement.enabled = false;
        }
        else playerMovement.enabled = true;
    }
    public void OpenDialog(Sprite NpcSprite, Color SpriteColor, string NpcName, string[] NpcDialog)
    {
        if (dialogCanvas.activeSelf) return;

        dialogCanvas.SetActive(true);
        DialogSyst.SpeakerSprite.sprite = NpcSprite;
        DialogSyst.SpeakerSprite.color = SpriteColor;
        DialogSyst.SpeakerName.text = NpcName;
        DialogSyst.SpeakerDialog = NpcDialog;
        DialogSyst.DialogDisplay.text = NpcDialog[0];
        DialogSyst.stringIndex = 0;
        Debug.Log(NpcName + " parle");
    }
    public void NextDialog()
    {
        DialogSyst.stringIndex++;
        if(DialogSyst.SpeakerDialog.Length > DialogSyst.stringIndex)
        {
            DialogSyst.DialogDisplay.text = DialogSyst.SpeakerDialog[DialogSyst.stringIndex];
        }
        else
        {
            dialogCanvas.SetActive(false);
        }
        
    }
}
