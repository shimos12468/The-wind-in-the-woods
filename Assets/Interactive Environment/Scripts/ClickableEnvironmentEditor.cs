/*
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ClickableEnvironment),true)]
public class ClickableEnvironmentEditor : Editor
{

    List<ClickableEnvironmentScriptableObject> interactiveEnvironment = new List<ClickableEnvironmentScriptableObject>();
    List<ClickableEnvironmentScriptableObject> CurrentTypeEnvoronment = new List<ClickableEnvironmentScriptableObject>();
    ClickableEnvironmentType type = ClickableEnvironmentType.None;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ClickableEnvironment clickableEnvironment = (ClickableEnvironment)target;
        if (type != clickableEnvironment.Type)
        {
            type= clickableEnvironment.Type;
            string[] files = Directory.GetFiles("Assets/Interactive Environment/Clickable Environment/", "*.asset", SearchOption.TopDirectoryOnly);
            interactiveEnvironment.Clear();
            foreach (var file in files)
            {
                ClickableEnvironmentScriptableObject prefab = AssetDatabase.LoadAssetAtPath(file, typeof(ClickableEnvironmentScriptableObject)) as ClickableEnvironmentScriptableObject;
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


        if (type == clickableEnvironment.Type)
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



    private void ShowEnvironment(ClickableEnvironmentScriptableObject environmentScriptableObject)
    {
        ClickableEnvironment interactive = (ClickableEnvironment)target;
        interactive.GetComponent<SpriteRenderer>().sprite = environmentScriptableObject.environmentInfo[0].sprite;
        interactive.GetComponent<SpriteRenderer>().material = environmentScriptableObject.environmentInfo[0].spriteMaterial;
        interactive.name = environmentScriptableObject.name;
        interactive.EnvironmentScriptableObject = environmentScriptableObject;

    }


}
*/
