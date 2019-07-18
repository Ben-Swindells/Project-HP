using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NpcController : MonoBehaviour
{
    [Header("NPC attributes")]
    public int currencyHeld;
    public string[] idleDialogue;
    public int health;

    [Header("Required Objects")]
    public TMP_Text idleDialogueUI;

    private float timeLeft = 6;
    private float wait = 2;


    // Start is called before the first frame update
    void Start()
    {
        idleDialogueUI.text = idleDialogue[Random.Range(0, idleDialogue.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        IdleDialgoueCounter();
    }
    void IdleDialgoueCounter()
    {
      timeLeft -= Time.deltaTime;

       if(timeLeft < 0)
      {
            idleDialogueUI.text = "";

            wait -= Time.deltaTime;

            if(wait < 0)
            {
                timeLeft = 6;

                idleDialogueUI.text = idleDialogue[Random.Range(0, idleDialogue.Length)];

                wait = 2;
            }
      }
    }

}
