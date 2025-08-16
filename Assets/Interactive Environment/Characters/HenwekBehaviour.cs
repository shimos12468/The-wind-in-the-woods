using RPG.Control;
using RPG.Dialogue;
using System;
using System.Collections.Generic;
using UnityEngine;

public class HenwekBehaviour : AIConversant
{


    [SerializeField] Dialogue middleQuest, finishedQuest;
    [SerializeField] Dialogue loop2Dialogue ,loop1Dialogue ,loop2middle ,loop2finish ,loop2fail;

    int numOfPlants = 4;
    int count = 0;

    public List<GameObject> plants;
    private void Awake()
    {
        LoopReset.Loop += Looping;
    }

    private void Looping(int obj)
    {
        if (obj == 1)
        {
            current = loop1Dialogue;
        }else if (obj == 2)
        {

            if (count != numOfPlants)
            {
                current= loop2fail;
            }
            else
            {
                foreach (GameObject go in plants)
                {
                    go.name = "Plant";
                }

                current= loop2Dialogue;
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

    public void PlayerPlantedSeeds()
    {

        count++;
        if (numOfPlants == count)
        {
            current = finishedQuest;

        }


    }
    int waterCount = 0;
    int numOfWater = 4;

    public void PlayerWateredPlant()
    {

        waterCount++;
        if (numOfWater == waterCount)
        {
            current = loop2finish;


            FindAnyObjectByType<EvelynBehaviour>().UnDispled();

        }


    }


    public void PlayerGotSeeds()
    {
        current = middleQuest;
    }

    public void PlayerGotWater()
    {
        current = loop2middle;
    }

}
