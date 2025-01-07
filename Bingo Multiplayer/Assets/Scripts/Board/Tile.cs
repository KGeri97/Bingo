using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    //Is this needed?
    private int _xPos = -1;
    private int _yPos = -1;
    private int _value = -1;

    private TMP_Text _textMesh;
    private Image _image;

    [SerializeField]
    private Color _colorSelected;
    [SerializeField]
    private Color _colorDeselected;
    private bool _isSelected;


    private void Awake() {
        _textMesh = GetComponentInChildren<TMP_Text>();
        _image = GetComponentInChildren<Image>();
    }

    public void OnClick() {
        _isSelected = !_isSelected;

        if (_isSelected)
            _image.color = _colorSelected;
        else
            _image.color = _colorDeselected;
    }

    public void Initialize(int x, int y, int value) {
        _xPos = x;
        _yPos = y;
        _value = value;

        _textMesh.text = value.ToString();
        _isSelected = false;
        _image.color = _colorDeselected;
    }
}
