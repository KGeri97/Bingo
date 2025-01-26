using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using TMPro;
using System;

public class GameVisualManager : NetworkBehaviour {

    public static GameVisualManager Instance;

    [Header("Viewports")]
    [SerializeField]
    private GameObject _clientContainer;
    [SerializeField]
    private GameObject _hostContainer;

    [Header("Prefabs")]
    [SerializeField]
    private GameObject _rowPrefab;
    [SerializeField]
    private GameObject _tilePrefab;

    [Header("UI Containers")]
    [SerializeField]
    private GameObject _gridSettingsContainer;
    public GameObject GridSettingsContainer => _gridSettingsContainer;
    [SerializeField]
    private GameObject _goalSettingsContainer;
    public GameObject GoalSettingsContainer => _goalSettingsContainer;
    [SerializeField]
    private GameObject _gameContainerHost;
    public GameObject GameContainerHost => _gameContainerHost;
    [SerializeField]
    private GameObject _gameContainerClient;
    public GameObject GameContainerClient => _gameContainerClient;

    [Header("Other")]
    [SerializeField]
    private TMP_Text _statusTextMesh;


    private void Awake() {
        if (Instance) {
            Debug.LogError($"There is already a Game Visual Manager existing. Deleting new one.");
            Destroy(gameObject);
            return;
        }
        Instance = this;

        if (GameManager.Instance.PlayerType == PlayerType.Client)
            _clientContainer.SetActive(true);
        else
            _hostContainer.SetActive(true);

        BoardUtils.InitializePrefabs(_tilePrefab, _rowPrefab);

        GameManager.Instance.State.OnValueChanged += OnStateChanged;
    }

    private void OnStateChanged(GameState olValue, GameState newValue) {
        switch (GameManager.Instance.State.Value) {
            case GameState.None:
                break;
            case GameState.Configuring:
                _statusTextMesh.text = "Please wait until the host is done configuring the game.";
                break;
            case GameState.Running:

                break;
        }

        Debug.Log("GameState changed");
    }
}
