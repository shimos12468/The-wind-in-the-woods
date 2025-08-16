using System;
using UnityEngine;
using UnityEngine.Events;

// This is just a test script to see if the OnLoop event is firing properly
public class TestObject : MonoBehaviour
{
    void OnEnable()
    {
        GameObject.FindGameObjectWithTag("LoopReset").GetComponent<LoopReset>().OnLoop.AddListener(ChangeSize);
    }

    private void OnDisable()
    {
        GameObject.FindGameObjectWithTag("LoopReset").GetComponent<LoopReset>().OnLoop.RemoveListener(ChangeSize);
    }

    private void ChangeSize()
    {
        this.transform.localScale *= 0.5f;
    }
}
