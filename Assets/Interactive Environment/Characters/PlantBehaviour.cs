using RPG.Control;
using RPG.Dialogue;
using System;
using UnityEngine;
using UnityEngine.Events;

public class PlantBehaviour : AIConversant
{

    public UnityEvent WateredPlant;

    public override void Behaviour(PlayerController playerController)
    {
        if (canInteract)
        {

            //if (Input.GetMouseButtonDown(0))
            //{
            //    var go = playerController.GetComponent<PlayerInventoryHandler>().Items.Find((x) => x.name == "Seeds");
            //    if (go)
            //    {
            //        playerController.GetComponent<PlayerNotifications>().showUI("press right click to plant seeds");
            //    }
            //    else
            //    {
            //        playerController.GetComponent<PlayerNotifications>().showUI("Go get seeds first baby");

            //    }
            //}
            //if (Input.GetMouseButtonDown(1))
            //{
            //    print("dasd");
            //    var go = playerController.GetComponent<PlayerInventoryHandler>().Items.Find((x) => x.name == "Seeds");
            //    if (go)
            //    {

            //        playerController.GetComponent<PlayerNotifications>().showUI("You Planted the seeds");
            //        //playerController.GetComponent<PlayerInventoryHandler>().Items.Remove(go);
            //        WateredPlant?.Invoke();
            //    }
            //}

        }

    }

    private void Awake()
    {
        LoopReset.Loop += Looping;
    }

    bool canInteract = false;
    private void Looping(int obj)
    {
        if (obj == 2)
        {
            canInteract = true;
        }

        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Seeds")
        {
            gameObject.name = "plant2";
            GetComponent<BoxCollider2D>().enabled= false;
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
