using Nobi.UiRoundedCorners;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(ImageWithRoundedCorners))]
[RequireComponent(typeof(Outline))]
public class RoundedUiObjectHelper : MonoBehaviour
{
    private Image _image;
    private ImageWithRoundedCorners _roundedCorners;
    private Outline _outline;

    [SerializeField] private Color _bgColor = Color.white;
    [SerializeField] private Color _outlineColor = Color.black;
    [SerializeField] private float _outlineThickness = 22.0f;
    [SerializeField] private float _roundingRadius = 64.0f;

    private void OnValidate()
    {
        if (_image == null) _image = GetComponent<Image>();
        if (_roundedCorners == null) _roundedCorners = GetComponent<ImageWithRoundedCorners>();
        if (_outline == null) _outline = GetComponent<Outline>();

        _image.color = _bgColor;
        _outline.effectColor = _outlineColor;

        _roundedCorners.radius = _roundingRadius;
        _outline.effectDistance = new Vector2(_outlineThickness, _outlineThickness);
    }
}
