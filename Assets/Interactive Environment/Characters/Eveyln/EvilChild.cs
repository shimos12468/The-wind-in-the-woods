using RPG.Control;
using RPG.Dialogue;
using System;
using UnityEngine;
using UnityEngine.Events;

public class EvilChild : AIConversant
{
    public override void Behaviour(PlayerController playerController)
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerController.GetComponent<PlayerConversant>().StartDialogue(this, current);
        }
    }

    public void Awake()
    {
        LoopReset.Loop += Looping;
    }
    private void Looping(int c)
    {
        if (c == 2)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;

        }
        else if (c == 1) 
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
