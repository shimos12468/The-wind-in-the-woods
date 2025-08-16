using UnityEngine;

public class FMODTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/DialogueClose");
    }
}
