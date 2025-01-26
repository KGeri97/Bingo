using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Tile : MonoBehaviour
{
    private TMP_Text _textMesh;
    private Image _image;
    private Button _tileButton;

    private int _xPos;
    private int _yPos;

    [SerializeField]
    private Color _colorSelected;
    [SerializeField]
    private Color _colorDeselected;

    private void OnEnable() {
        GameManager.Instance.OnTileClicked += OnTileClicked;
    }

    private void OnDisable() {
        GameManager.Instance.OnTileClicked -= OnTileClicked;
    }

    private void Awake() {
        _textMesh = GetComponentInChildren<TMP_Text>();
        _image = GetComponent<Image>();
        _tileButton = GetComponent<Button>();
        _tileButton.onClick.AddListener(OnClick);
    }

    public void OnClick() {
        GameManager.Instance.ClickedOnTile(_xPos, _yPos);
    }

    private void OnTileClicked(object sender, GameManager.OnTileClickedEventArgs e) {
        if (e.X != _xPos || e.Y != _yPos)
            return;

        if (e.Selected) {
            _image.color = _colorSelected;
        }
        else {
            _image.color = _colorDeselected;
        }

    }

    public void Initialize(int x, int y, int value, bool isSelected) {
        _xPos = x;
        _yPos = y;
        _textMesh.text = value.ToString();

        if (isSelected) {
            _image.color = _colorSelected;
        }
        else {
            _image.color = _colorDeselected;
        }

    }
}
