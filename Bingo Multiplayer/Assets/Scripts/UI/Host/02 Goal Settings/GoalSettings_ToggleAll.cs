using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GoalSettings_ToggleAll : MonoBehaviour
{
    private Button _toggleAllButton;
    private TMP_Text _buttonText;
    private int _gridWidth;
    private int _gridHeight;
    private bool _isSelecting = true;

    private void OnEnable() {
        GameManager.Instance.OnGoalAdded += OnGoalAdded;
    }

    private void OnDisable() {
        GameManager.Instance.OnGoalAdded -= OnGoalAdded;
    }

    private void Awake() {
        _toggleAllButton = GetComponent<Button>();
        _buttonText = GetComponentInChildren<TMP_Text>();

        _toggleAllButton.onClick.AddListener(ToggleAll);

        _gridWidth = GameManager.Instance.Columns;
        _gridHeight = GameManager.Instance.Rows;
    }

    private void ToggleAll() {
        for (int y = 0; y < _gridHeight; y++) {
            for (int x = 0; x < _gridWidth; x++) {
                GameManager.Instance.ClickedOnTile(x, y, _isSelecting);
            }
        }

        _isSelecting = !_isSelecting;

        if (_isSelecting) {
            _buttonText.text = "Select all";
        }
        else {
            _buttonText.text = "Deselect all";
        }
    }

    private void OnGoalAdded(object sender, GameManager.OnGoalAddedEventArgs e) {
        foreach (Vector2 coords in e.Goal.TileCoordinates) {
            GameManager.Instance.ClickedOnTile((int)coords.x, (int)coords.y, false);
        }

        _isSelecting = true;
        _buttonText.text = "Select all";
    }
}
