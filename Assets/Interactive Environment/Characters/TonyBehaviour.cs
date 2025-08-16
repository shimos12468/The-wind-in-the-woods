using GameDevTV.Utils;
using RPG.Control;
using RPG.Dialogue;
using System;
using UnityEngine;

public class TonyBehaviour : AIConversant 
{


    [SerializeField] Dialogue loop1Start, loop2Start,foundItem,finishedQuest, middleOfQuest ,forestDialogue;

    [SerializeField] Dialogue foundGlassesAgain, middleLoop2, finishedLoop2Quest;

    [SerializeField] Vector3 loop2StartPos;
    [SerializeField] Transform forest;
    [SerializeField] Collider2D boxCollider;
    private void Awake()
    {

        LoopReset.Loop += Looping;

    }

    private void Looping(int obj)
    {
        if (obj == 2)
        {
            current = loop2Start;
             transform.localPosition= loop2StartPos;
            boxCollider.gameObject.SetActive(true);
        }

        if (obj == 1)
        {
            current = loop1Start;
            loop2StartPos = transform.localPosition;
        }

    }

    public override void Behaviour(PlayerController playerController)
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerController.GetComponent<PlayerConversant>().StartDialogue(this, current);
        }
        }

    public void OnMissionStarted()
    {
        current = middleOfQuest;
    }

    public void OnFoundItem()
    {
        current = foundItem;
    }


    public void OnFinishedQuest()
    {
        current = finishedQuest;
    }

    public void PlayerFoundGlasses()
    {
        current = foundItem;
        //var go = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventoryHandler>().Items.Find((x) => x.name == "Glasses");
        //if (go)
        //{
        //    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventoryHandler>().Items.Remove(go);
        //}

    }
    public void FoundGlassesAgain()
    {
        current = foundGlassesAgain;

    }

    public void FinishedGlassesLoop2()
    {
        current = finishedLoop2Quest;

    }
    public void MiddleLoop2()
    {
        current = middleLoop2;

    }

    public void OpenGate()
    {
        print("Open Gate");
    }

    public void OnGoToForest()
    {
        current= forestDialogue;
        transform.position = forest.position;
    }


}
