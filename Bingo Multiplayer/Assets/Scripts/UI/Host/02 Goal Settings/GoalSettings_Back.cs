using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalSettings_Back : MonoBehaviour
{
    private Button _backButton;

    private GameObject _gridSettingsContainer;
    private GameObject _goalSettingsContainer;

    private void Awake() {
        _backButton = GetComponent<Button>();

        _backButton.onClick.AddListener(Back);
    }

    private void Start() {
        _gridSettingsContainer = GameVisualManager.Instance.GridSettingsContainer;
        _goalSettingsContainer = GameVisualManager.Instance.GoalSettingsContainer;
    }

    private void Back() {
        UIUtils.ChangeMenu(_goalSettingsContainer, _gridSettingsContainer);
    }
}
