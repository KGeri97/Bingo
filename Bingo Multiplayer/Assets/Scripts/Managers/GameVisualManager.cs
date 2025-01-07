using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVisualManager : MonoBehaviour {

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
    [SerializeField]
    private Transform _gridContainer;

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
        //BoardUtils.DrawBoard(board, _tilePrefab, _rowPrefab, _gridContainer);
    }

    private void Update(){
    }
}
