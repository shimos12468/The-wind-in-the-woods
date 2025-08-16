using System;
using UnityEngine;
using UnityEngine.Events;

// The creation of the OnLoop event where ideally all reloading functions will subscribe to.
public class LoopReset : MonoBehaviour
{
    public UnityEvent OnLoop;
    public static Action<int> Loop;
    public int count = 0;
    private void Start()
    {
        Loop?.Invoke(count);
        count++;
    }


    public  void TriggerLoop()
    {
        Debug.Log("OnLoop is firing!");
        OnLoop.Invoke();

        Loop?.Invoke(count);
        count++;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

                        
          
        }
    }
}
