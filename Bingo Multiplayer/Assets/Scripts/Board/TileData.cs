using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TileData {

    public int Value;
    public bool IsSelected;

    public TileData(int value) {
        Value = value;
        IsSelected = false;
    }

    public void ToggleSelection() {
        IsSelected = !IsSelected;
    }
}
