using RPG.Control;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Dialogue
{
    public abstract class AIConversant : MonoBehaviour, IRaycastable
    {
        [SerializeField] public Dialogue current = null;
        [SerializeField] string conversantName;
        
        public CursorType GetCursorType()
        {
            return CursorType.Dialogue;
        }

        public bool HandleRaycast(PlayerController callingController)
        {
            if (current == null)
            {
                return false;
            }
          
                Behaviour(callingController);
            
            return true;
        }

        public string GetName()
        {
            return conversantName;
        }


        public abstract void Behaviour(PlayerController playerController);
    }
}

[Serializable]
public struct DialogueCondition
{
    public string condition;
    public bool state;
}