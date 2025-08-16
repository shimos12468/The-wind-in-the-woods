using RPG.Control;
using RPG.Dialogue;
using System;
using UnityEngine;
using UnityEngine.Events;

public class ChildBehaviour : AIConversant
{
    public UnityEvent GotFound;

    public override void Behaviour(PlayerController playerController)
    {
        if (Input.GetMouseButtonDown(0))
        {
            GotFound?.Invoke();
            gameObject.SetActive(false);
        }
    }


    private void Awake()
    {
        LoopReset.Loop += Looping;
    }
    bool canInteract =false;
    private void Looping(int obj)
    {
        


        if (obj == 1)
        {
            canInteract= true;
        }
        if (obj == 2)
        {
            Destroy(gameObject);
        }
    }
}
