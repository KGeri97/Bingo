using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal
{
    public List<Vector2> TileCoordinates;
    public bool IsActive;

    public Goal(List<Vector2> tileCoordinates) {
        TileCoordinates = tileCoordinates;
        IsActive = true;
    }
}
