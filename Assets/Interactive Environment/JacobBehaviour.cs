using RPG.Control;
using RPG.Dialogue;
using System;
using UnityEngine;

public class JacobBehaviour : AIConversant{


    [SerializeField] Dialogue loop1Dialogue, loop2Dialogue ,carrotDialogue,BreadDialogue;
    public override void Behaviour(PlayerController playerController)
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerController.GetComponent<PlayerConversant>().StartDialogue(this, current);
        }
    }


    private void Awake()
    {
        LoopReset.Loop += Looping;
    }

    private void Looping(int obj)
    {
        if (obj == 1)
        {
            current = loop1Dialogue;
        }
        else if (obj == 2)
        {
            current = loop2Dialogue;
        }
    }



    public void GotFood(bool b)
    {
        if (b == true)
        {
            current = carrotDialogue;
        }
        else
        {
            current = BreadDialogue;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
