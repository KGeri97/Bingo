using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSettings_BoardDrawer : MonoBehaviour
{
    private void OnEnable() {
        BoardUtils.DrawBoard(GameManager.Instance.LocalBoard, transform);
    }
}
