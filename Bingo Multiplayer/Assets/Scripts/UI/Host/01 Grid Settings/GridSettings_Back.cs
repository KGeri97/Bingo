using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class GridSettings_Back : MonoBehaviour
{
    private Button _gridSettingsBack;

    private void Awake() {
        _gridSettingsBack = GetComponent<Button>();
        _gridSettingsBack.onClick.AddListener(Back);
    }

    private void Back() {
        //Disconnection should be handled properly
        #region Disconnect
        if (GameManager.Instance.PlayerType == PlayerType.Client)
            NetworkManager.Singleton.DisconnectClient(NetworkManager.Singleton.LocalClientId);
        else
            NetworkManager.Singleton.Shutdown();

        GameManager.Instance.SetPlayerType(PlayerType.None);
        #endregion

        SceneManager.ChangeScene(Scenes.MainMenuScene);
    }
}
