using RPG.Control;
using System.Threading.Tasks;
using UnityEngine;

public abstract class ClickableEnvironment : MonoBehaviour 
{
    [SerializeField] ClickableEnvironmentScriptableObject clickableEnvironmentScriptableObject;

    public ClickableEnvironmentScriptableObject EnvironmentScriptableObject { get { return clickableEnvironmentScriptableObject; } set { clickableEnvironmentScriptableObject = value; } }


    [SerializeField] ClickableEnvironmentType type;
    public ClickableEnvironmentType Type { get { return type; } }
    private void Awake()
    {

    }

    public abstract void Loop(int num);

    public void ChangeEnvironment(int index)
    {
        GetComponent<SpriteRenderer>().sprite = clickableEnvironmentScriptableObject.environmentInfo[index].sprite;

    }

    public async Task Delay()
    {
        await Task.Delay(10000);
    }
}