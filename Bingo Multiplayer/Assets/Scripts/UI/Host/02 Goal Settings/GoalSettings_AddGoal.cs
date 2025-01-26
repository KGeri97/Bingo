using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalSettings_AddGoal : MonoBehaviour
{
    private Button _addGoalButton;

    private void Awake() {
        _addGoalButton = GetComponent<Button>();

        _addGoalButton.onClick.AddListener(AddGoal);
    }

    private void AddGoal() {
        List<Vector2> tileCoordinates = new();
        Board board = GameManager.Instance.LocalBoard;

        for (int y = 0; y < board.Grid.GetLength(1); y++) {
            for (int x = 0; x < board.Grid.GetLength(0); x++) {
                if (board.Grid[x, y].IsSelected)
                    tileCoordinates.Add(new Vector2(x, y));
            }
        }

        if (tileCoordinates.Count == 0) {
            Debug.LogError("A goal must contain at least 1 tile");
            return;
        }

        Goal goal = new(tileCoordinates);

        //This needs to check if the Goal.TileCoordinates match
        //if (GameManager.Instance.Goals.Contains(goal)) {
        //    Debug.LogError("This goal already exists");
        //    return;
        //}

        GameManager.Instance.AddGoal(goal);
    }
}
