using System;
using System.Collections.Generic;
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
    private NetworkVariable<GameState> _state = new NetworkVariable<GameState>();
    public NetworkVariable<GameState> State => _state;

    private List<Board> _boards = new();
    private Board _localBoard;
    public Board LocalBoard => _localBoard;

    private List<Goal> _goals;
    public List<Goal> Goals => _goals;

    public event EventHandler<OnTileClickedEventArgs> OnTileClicked;
    public class OnTileClickedEventArgs : EventArgs {
        public int X;
        public int Y;
        public bool Selected;
    }

    public event EventHandler<OnGoalAddedEventArgs> OnGoalAdded;
    public class OnGoalAddedEventArgs : EventArgs {
        public Goal Goal;
    }

    //public event EventHandler OnStateChanged;

    private void Awake() {
        if (Instance) {
            Debug.LogError($"There is already a game manager existing. Deleting new one.");
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            _state.Value = GameState.Running;
        }
    }

    #region Settings
    public void SetPlayerType(PlayerType type) {
        PlayerType = type;
    }

    //Can only run on server
    public void SetGridParams(int columns, int rows, int maxNumber) {
        _columns = columns;
        _rows = rows;
        _maxNumber = maxNumber;

        _boards.Add(new Board(_columns, _rows));
        _localBoard = _boards[0];

        _goals = new();
    }
    #endregion

    public override void OnNetworkSpawn() {
        //Debug.Log(message: "On network spawn: " + NetworkManager.Singleton.LocalClientId, context: this);

        if (IsServer) {
            NetworkManager.Singleton.OnClientConnectedCallback += NetworkManager_OnClientConnectedCallback;
        }

        _state.OnValueChanged += OnStateChanged;
        Debug.Log("Signed up");
    }

    private void NetworkManager_OnClientConnectedCallback(ulong obj) {
    }

    /// <summary>
    /// Toggles the selection of the tile
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public void ClickedOnTile(int x, int y) {
        _localBoard.Grid[x, y].ToggleSelection();
        OnTileClicked?.Invoke(this, new OnTileClickedEventArgs {
            X = x,
            Y = y,
            Selected = _localBoard.Grid[x, y].IsSelected
        });
    }

    /// <summary>
    /// Sets the selected value of the tile
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="selected"></param>
    public void ClickedOnTile(int x, int y, bool selected) {
        _localBoard.Grid[x, y].IsSelected = selected;
        OnTileClicked?.Invoke(this, new OnTileClickedEventArgs {
            X = x,
            Y = y,
            Selected = _localBoard.Grid[x, y].IsSelected
        });
    }

    public void AddGoal(Goal goal) {
        _goals.Add(goal);
        OnGoalAdded?.Invoke(this, new OnGoalAddedEventArgs() { 
            Goal = goal});
    }

    public void ChangeGameState(GameState state) {
        _state.Value = state;
    }

    private void OnStateChanged(GameState olValue, GameState newValue) {
        
    }
}

public enum PlayerType {
    None,
    Client,
    Host
}

public enum GameState {
    None,
    Configuring,
    Running,
    Paused,
    Validating,
    //Finished
}
