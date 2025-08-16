using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class DigitallyNavigableButton : MonoBehaviour
{
    private DigitallyNavigableButtonContainer _container;


    //[SerializeField] GameObject _targetObject;
    [SerializeField] string _key;

    [SerializeField] UnityEvent _onHighlighted;
    [SerializeField] UnityEvent _onDehighlighted;
    [SerializeField] UnityEvent _onSubmitted;

    public UnityEvent OnHighlighted => _onHighlighted;
    public UnityEvent OnDehighlighted => _onDehighlighted;
    public UnityEvent OnSubmitted => _onSubmitted;

    private void Start()
    {
        SetContainer();

        //Developer error cases
        if (_key == string.Empty)
            Debug.LogWarning($"Key for {gameObject.name} is not set -- button navigation might break");
    }

    void SetContainer()
    {
        DigitallyNavigableButtonContainer containerOut;
        foreach (Transform childTransform in this.transform.parent)
        {
            if (childTransform.TryGetComponent<DigitallyNavigableButtonContainer>(out containerOut))
            {
                _container = containerOut;
                break;
            }
        }
        if (_container == null)
        {
            Debug.LogWarning($"No obj with component \'DigitallyNavigableButtonContainer\' found as a sister of {gameObject.name}");
        }
    }
}
