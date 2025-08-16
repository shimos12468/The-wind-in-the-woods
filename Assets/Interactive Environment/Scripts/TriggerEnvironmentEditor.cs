/*
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TriggerEnvironment), true)]
public class TriggerEnvironmentEditor : Editor
{

    List<TriggerEnvironmentScriptableObject> interactiveEnvironment = new List<TriggerEnvironmentScriptableObject>();
    List<TriggerEnvironmentScriptableObject> CurrentTypeEnvoronment = new List<TriggerEnvironmentScriptableObject>();
    TriggerEnvironmentType type = TriggerEnvironmentType.None;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        TriggerEnvironment triggerEnvornment = (TriggerEnvironment)target;
        
        
        if (triggerEnvornment.GetComponent<BoxCollider2D>().isTrigger==false)
        {
            triggerEnvornment.GetComponent<BoxCollider2D>().isTrigger= true;
        }
        
        
        if (type != triggerEnvornment.Type)
        {
            type = triggerEnvornment.Type;
            string[] files = Directory.GetFiles("Assets/Interactive Environment/Trigger Environment/", "*.asset", SearchOption.TopDirectoryOnly);
            interactiveEnvironment.Clear();
            foreach (var file in files)
            {
                TriggerEnvironmentScriptableObject prefab = AssetDatabase.LoadAssetAtPath(file, typeof(TriggerEnvironmentScriptableObject)) as TriggerEnvironmentScriptableObject;
                interactiveEnvironment.Add(prefab);
            }
            CurrentTypeEnvoronment.Clear();
            foreach (var file in interactiveEnvironment)
            {
                if (file.environmentType == type)
                {

                    CurrentTypeEnvoronment.Add(file);
                }
            }

            Draw();
        }


        if (type == triggerEnvornment.Type)
        {

            Draw();
        }
    }


    private void Draw()
    {

        for (int i = 0; i < CurrentTypeEnvoronment.Count; i++)
        {
            if (GUILayout.Button(CurrentTypeEnvoronment[i].name))
            {

                ShowEnvironment(CurrentTypeEnvoronment[i]);
            }

        }
    }



    private void ShowEnvironment(TriggerEnvironmentScriptableObject environmentScriptableObject)
    {
        TriggerEnvironment interactive = (TriggerEnvironment)target;
        interactive.GetComponent<SpriteRenderer>().sprite = environmentScriptableObject.environmentInfo[0].sprite;
        interactive.GetComponent<SpriteRenderer>().material = environmentScriptableObject.environmentInfo[0].spriteMaterial;
        interactive.name = environmentScriptableObject.name;
        interactive.EnvironmentScriptableObject = environmentScriptableObject;

    }

}
*/
