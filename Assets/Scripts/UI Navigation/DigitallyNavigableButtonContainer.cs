using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DigitallyNavigableButtonContainer : MonoBehaviour
{
    [Serializable] public struct StrKeyButtonPair
    {
        public string Key;
        public DigitallyNavigableButton DigitallyNavigableButton;
    }

    [SerializeField] private List<StrKeyButtonPair> _buttons;
    public List<StrKeyButtonPair> Buttons => _buttons;

    private int _highlightIndex = 0;
    private bool _wasBtnPreviouslyHighlightedViaDigital = false;

    private PlayerInputActions _inputActions;
    private InputActionMap _uiActionMap;

    private void Awake()
    {
        _inputActions = new PlayerInputActions();
        _uiActionMap = _inputActions.UI;
    }

    private void OnEnable()
    {
        _inputActions.Enable();
        _uiActionMap.FindAction("Navigate").performed += OnForwardTheNavigation;
        _uiActionMap.FindAction("Submit").performed += OnSubmit;
    }

    private void OnDisable()
    {
        _inputActions.Disable();
        _uiActionMap.FindAction("Navigate").performed -= OnForwardTheNavigation;
        _uiActionMap.FindAction("Submit").performed -= OnSubmit;
    }

    public void OnForwardTheNavigation(InputAction.CallbackContext ctx)
    {
        int navigation = 0;
        if (ctx.ReadValue<Vector2>().y < 0 || ctx.ReadValue<Vector2>().x > 0)
            navigation = 1;
        else if (ctx.ReadValue<Vector2>().y > 0 || ctx.ReadValue<Vector2>().x < 0)
            navigation = -1;
        NavigateButtons(navigation);
    }

    public void NavigateButtons(int navigation)
    {
        if (!_wasBtnPreviouslyHighlightedViaDigital)
        {
            _highlightIndex = 0;
            GetButtonAtListIndex(0).OnHighlighted.Invoke();
            _wasBtnPreviouslyHighlightedViaDigital = true;
        }
        else
        {
            if (navigation == 0) return;
            GetButtonAtListIndex(_highlightIndex).OnDehighlighted.Invoke();
            _highlightIndex += navigation;
            //Clamp and loop-over the index
            if (_highlightIndex < 0 ) _highlightIndex = _buttons.Count - 1;
            if (_highlightIndex > _buttons.Count - 1) _highlightIndex = 0;
            GetButtonAtListIndex(_highlightIndex).OnHighlighted.Invoke();
        }

    }

    public void OnSubmit(InputAction.CallbackContext _) => GetButtonAtListIndex(_highlightIndex).OnSubmitted.Invoke();

    public DigitallyNavigableButton GetButtonAtListIndex(int index) => _buttons[index].DigitallyNavigableButton;

    public DigitallyNavigableButton GetButtonViaStringIndex(string key)
    {
        foreach(StrKeyButtonPair b in _buttons)
        {
            if (key.Equals(b.Key))
                return b.DigitallyNavigableButton;
        }

        throw new ArgumentException();
        //return null;
    }
}
