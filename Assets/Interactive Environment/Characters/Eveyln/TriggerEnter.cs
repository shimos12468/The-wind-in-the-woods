using Unity.VisualScripting;
using UnityEngine;

public class TriggerEnter : MonoBehaviour
{

    public LoopReset loopReset;

    private void Awake()
    {
        loopReset = GameObject.FindWithTag("WorldManager").GetComponent<LoopReset>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            loopReset.TriggerLoop();


            Debug.Log("OnLoop is firing!");
            
        }
    }

    
}
