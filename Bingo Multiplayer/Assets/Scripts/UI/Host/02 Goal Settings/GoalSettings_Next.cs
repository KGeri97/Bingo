using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalSettings_Next : MonoBehaviour {
    private Button _nextButton;

    private GameObject _goalSettingsContainer;
    private GameObject _gameContainerHost;

    private void Awake() {
        _nextButton = GetComponent<Button>();

        _nextButton.onClick.AddListener(Next);
    }

    private void Start() {
        _goalSettingsContainer = GameVisualManager.Instance.GoalSettingsContainer;
        _gameContainerHost = GameVisualManager.Instance.GameContainerHost;
    }

    private void Next() {
        UIUtils.ChangeMenu(_goalSettingsContainer, _gameContainerHost);
    }
}
