using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//For use only in TitleScreenScene
public class TitleScreenButton : MonoBehaviour
{
    [SerializeField] Button _button;
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] RectTransform _titleScreenPanel;
    [SerializeField] GameObject _creditsPanel;

    ColorBlock _cBlock;

    private void Start()
    {
        if ( _button == null ) _button = GetComponent<Button>();
        //if (_image == null) _image = _button.image;

        _cBlock = _button.colors;
    }



    public void Highlight()
    {
        StopAllCoroutines();
        StartCoroutine(LerpColorCoroutine(_cBlock.normalColor, _cBlock.highlightedColor, _cBlock.fadeDuration));
    }

    public void Dehighlight()
    {
        StopAllCoroutines();
        StartCoroutine(LerpColorCoroutine(_cBlock.highlightedColor, _cBlock.normalColor, _cBlock.fadeDuration));
    }

    public void SubmitAny()
    {
        StopAllCoroutines();
        StartCoroutine(LerpColorCoroutine(_cBlock.normalColor, _cBlock.pressedColor, _cBlock.fadeDuration, true));
    }

    private IEnumerator LerpColorCoroutine(Color startColor, Color targetColor, float duration, bool shouldReturnToStart = false)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float tt = Mathf.Clamp01(elapsedTime / duration);
            _text.color = Color.Lerp(startColor, targetColor, tt);
            yield return null;
        }

        if (shouldReturnToStart)
        {
            float elapsedTimeX = 0f;
            while (elapsedTimeX < duration)
            {
                elapsedTimeX += Time.deltaTime;
                float tu = Mathf.Clamp01(elapsedTimeX / duration);
                _text.color = Color.Lerp(targetColor, startColor, tu);
                yield return null;
            }
        }
    }

    #region Exposed methods for DigitallyNavigableButton's OnSubmitted.Invoke()
    public void OnStartChosen()
    {
        Debug.Log("The START GAME button was pressed");
        SceneManager.LoadScene(1);
    }

    public void OnCreditsChosen()
    {
        Debug.Log("The CREDITS button was pressed");
        _creditsPanel.SetActive(true);
    }
    #endregion

    #region Ghost code
    public void DbgPrintHighlighted(string key)
    {
        Debug.Log($"Button \'{key}\' was highlighted");
    }
    public void DbgPrintDeHighlighted(string key)
    {
        Debug.Log($"Button \'{key}\' was DE-highlighted");
    }
    //void Update()
    //{
    //    if (!_creditsPanelIsShowing) return;

    //    if (_bufferFramesElapsed < BufferFrames)
    //    {
    //        _bufferFramesElapsed++;
    //        return;
    //    }

    //    _bufferFramesElapsed = 0;
    //    if (Input.anyKeyDown)
    //    {
    //        Debug.Log("This got triggered really fast...");
    //        _creditsPanel.SetActive(false);
    //        _creditsPanelIsShowing = false;
    //        SendToAlaska(true);
    //    }

    //private void SendToAlaska(bool isReturning)
    //{
    //    _titleScreenPanel.position = new Vector3(_titleScreenPanel.position.x,
    //        _titleScreenPanel.position.y + (isReturning ? -1500f : 1500f),
    //        _titleScreenPanel.position.z);
    //}
    #endregion
}
