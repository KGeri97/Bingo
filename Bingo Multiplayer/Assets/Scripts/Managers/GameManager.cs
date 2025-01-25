using Unity.Netcode;
using UnityEngine;

public class GameManager : NetworkBehaviour {
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private int _columns;
    public int Columns => _columns;
    [SerializeField]
    private int _rows;
    public int Rows => _rows;
    [SerializeField]
    private int _maxNumber;
    public int MaxNumber => _maxNumber;

    public PlayerType PlayerType{ get; private set; }

    public Board Board;


    private void Awake() {
        if (Instance) {
            Debug.LogError($"There is already a game manager existing. Deleting new one.");
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    #region Settings
    public void SetPlayerType(PlayerType type) {
        PlayerType = type;
    }

    public void SetGridParams(int columns, int rows, int maxNumber) {
        _columns = columns;
        _rows = rows;
        _maxNumber = maxNumber;
    }
    #endregion

    public override void OnNetworkSpawn() {
        Debug.Log(message: "On network spawn: " + NetworkManager.Singleton.LocalClientId, context: this);
    }
}

public enum PlayerType {
    None,
    Client,
    Host
}
