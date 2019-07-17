using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NpcController : MonoBehaviour
{
    [Header("NPC attributes")]
    public int currencyHeld;
    public string idleDialogue;
    public int health;

    [Header("Required Objects")]
    public TMP_Text idleDialogueUI;


    // Start is called before the first frame update
    void Start()
    {

        idleDialogueUI.text = idleDialogue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
