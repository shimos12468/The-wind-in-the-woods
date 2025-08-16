using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class TriggerEnvironment : MonoBehaviour
{

    [SerializeField] TriggerEnvironmentScriptableObject triggerenvironmentScriptableObject;
   
    public TriggerEnvironmentScriptableObject EnvironmentScriptableObject { get { return triggerenvironmentScriptableObject; } set { triggerenvironmentScriptableObject = value; } }

    [SerializeField] TriggerEnvironmentType type;
    public TriggerEnvironmentType Type { get { return type; } }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnEnvironmentTriggerEnter(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnEnvironmentTriggerEXit(collision);
    }
    public abstract void Loop(int num);
    public void ChangeEnvironment(int index)
    {
        GetComponent<SpriteRenderer>().sprite = triggerenvironmentScriptableObject.environmentInfo[index].sprite;

    }

    public abstract void OnEnvironmentTriggerEnter(Collider2D collision);
    public abstract void OnEnvironmentTriggerEXit(Collider2D collision);

}
