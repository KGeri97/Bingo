using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneHostButtons : MonoBehaviour {

    [Header("Buttons")]
    [SerializeField]
    private Button _gridSettingsBack;
    [SerializeField]
    private Button _gridSettingsNext;

    [Header("Input Fields")]
    [SerializeField]
    private TMP_InputField _gridSettingsColumns;
    [SerializeField]
    private TMP_InputField _gridSettingsRows;
    [SerializeField]
    private TMP_InputField _gridSettingsMaxNumber;

    [Header("UI Containers")]
    [SerializeField]
    private GameObject _gridSettingsContainer;
    [SerializeField]
    private GameObject _goalSettingsContainer;


    private void Awake() {
        _gridSettingsBack.onClick.AddListener(Disconnect);
        _gridSettingsNext.onClick.AddListener(SubmitGridSettings);
    }

    private void Disconnect() {
        if (GameManager.Instance.PlayerType == PlayerType.Client)
            NetworkManager.Singleton.DisconnectClient(NetworkManager.Singleton.LocalClientId);
        else
            NetworkManager.Singleton.Shutdown();

        GameManager.Instance.SetPlayerType(PlayerType.None);
        SceneManager.ChangeScene(Scenes.MainMenuScene);
    }

    private void ChangeMenu(GameObject currentMenu, GameObject nextMenu) {
        currentMenu.SetActive(false);
        nextMenu.SetActive(true);
    }

    private void SubmitGridSettings() {
        GameManager.Instance.SetGridParams( int.Parse(_gridSettingsColumns.text),
                                            int.Parse(_gridSettingsRows.text),
                                            int.Parse(_gridSettingsMaxNumber.text) );
        ChangeMenu(_gridSettingsContainer, _goalSettingsContainer);
    }
}
