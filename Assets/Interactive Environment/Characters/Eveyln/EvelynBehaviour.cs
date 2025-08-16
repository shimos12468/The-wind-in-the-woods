using RPG.Control;
using RPG.Dialogue;
using System;
using UnityEngine;
using UnityEngine.Events;

public class EvelynBehaviour : AIConversant
{
    [Header("Loop 1")]
    [SerializeField] Dialogue middleOfQuest, finishedQuest ,loop1Start;
    public UnityEvent foundKids;
    public int numOfKids = 3;

    [Header("Loop 2")]
    [SerializeField] Dialogue foundKidsDialogueLoop2 , didntFinddKidsDialogueLoop2 ,gotFoodDialogue ,displedDialogue;
    private void Awake()
    {
        LoopReset.Loop += Looping;
    }

    private void Looping(int obj)
    {
        if (obj == 2)
        {

            current = displedDialogue;
           
        }
        if (obj == 1)
        {
            current = loop1Start;
        }

    }

    public void UnDispled()
    {
        if (count == numOfKids)
        {
            current = foundKidsDialogueLoop2;

        }
        else
        {

            current = didntFinddKidsDialogueLoop2;
        }
    }

    public override void Behaviour(PlayerController playerController)
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerController.GetComponent<PlayerConversant>().StartDialogue(this, current);
        }
    }

   
    public void StartedLoop1Mission()
    {
        current = middleOfQuest;
    }

    int count = 0;
    public void GotAKid()
    {
        count++;
       
        if (count==numOfKids)
        {
            FinishedLoop1Mission();
            
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerNotifications>().showUI("Go Talk to mom");
            foundKids?.Invoke();
        }


    }

    public void GotFood()
    {
        current = gotFoodDialogue;
    }
    public void FinishedLoop1Mission()
    {
        current= finishedQuest;
    }

}
