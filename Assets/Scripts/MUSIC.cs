using UnityEngine;

public class MUSIC : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Music");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
