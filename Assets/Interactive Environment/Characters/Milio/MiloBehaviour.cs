using RPG.Control;
using RPG.Dialogue;
using System;
using UnityEngine;

public class MiloBehaviour : AIConversant
{

    [SerializeField] Dialogue loop1Start,foundKids ,evil,good;

    [SerializeField] Dialogue loop2StartGood, loop2StartBad;
    private void Awake()
    {

        LoopReset.Loop += Looping;
    }

    private void Looping(int obj)
    {
        if (obj == 1)
        {

            current = loop1Start;

        }
        else if (obj == 2)
        {
            if (isGood)
            {
                current= loop2StartGood;
            }
            else
            {
                current = loop2StartBad;

            }

        }
        
    }

    public override void Behaviour(PlayerController playerController)
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerController.GetComponent<PlayerConversant>().StartDialogue(this, current);
        }
        }

   public void Triggered()
   {
        current = foundKids;
   }

    bool isGood = false;
    public void PlayerChangedHim(bool changed)
    {
        if (changed)
        {
            current = good;
            isGood= true;
        }
        else
        {
            current = evil;
            isGood= false;
        }
    }

}
