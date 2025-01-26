using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridSettings_NextButton : MonoBehaviour {

    private Button _gridSettingsNextButton;

    [Header("Input Fields")]
    [SerializeField]
    private TMP_InputField _gridSettingsColumns;
    [SerializeField]
    private TMP_InputField _gridSettingsRows;
    [SerializeField]
    private TMP_InputField _gridSettingsMaxNumber;

    private GameObject _gridSettingsContainer;
    private GameObject _goalSettingsContainer;

    private void Awake() {
        _gridSettingsNextButton = GetComponent<Button>();

        _gridSettingsNextButton.onClick.AddListener(SubmitGridSettings);
    }

    private void Start() {
        _gridSettingsContainer = GameVisualManager.Instance.GridSettingsContainer;
        _goalSettingsContainer = GameVisualManager.Instance.GoalSettingsContainer;
    }

    private void SubmitGridSettings() {
        GameManager.Instance.SetGridParams(int.Parse(_gridSettingsColumns.text),
                                            int.Parse(_gridSettingsRows.text),
                                            int.Parse(_gridSettingsMaxNumber.text));
        UIUtils.ChangeMenu(_gridSettingsContainer, _goalSettingsContainer);

        //BoardUtils.DrawBoard(_goalSettingsBoardContainer.transform); // The board needs to draw when the new menu appears
    }
}
