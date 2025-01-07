using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ViewSettings
{
    public static float AspectRatio { get; private set; }
    public static float WorldHeight { get; private set; }
    public static float WorldWidth { get; private set; }

    public static Vector4 Padding { get; private set; }

    public static void SetScreenSizeVariables() {
        AspectRatio = (float)Screen.width / Screen.height;
        WorldHeight = Camera.main.orthographicSize * 2;
        WorldWidth = WorldHeight * AspectRatio;

        //Temp solution Shall be done different
        Padding = new Vector4(0.2f, 0.2f, 0.2f, 0.2f);
    }
}
