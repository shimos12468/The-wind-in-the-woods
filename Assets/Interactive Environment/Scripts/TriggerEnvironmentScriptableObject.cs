using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Trigger Environment instance" ,menuName ="Trigger Intractable Environment",order =0)]
public class TriggerEnvironmentScriptableObject : ScriptableObject
{
    public TriggerEnvironmentType environmentType;
    public List<InteractableEnvironmentInfo> environmentInfo = new List<InteractableEnvironmentInfo>();
}


