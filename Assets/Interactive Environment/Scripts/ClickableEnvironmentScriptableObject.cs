using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Clickable Environment instance", menuName = "Clickable Intractable Environment", order = 0)]
public class ClickableEnvironmentScriptableObject : ScriptableObject
{
    public ClickableEnvironmentType environmentType;
    public List<InteractableEnvironmentInfo> environmentInfo = new List<InteractableEnvironmentInfo>();
}