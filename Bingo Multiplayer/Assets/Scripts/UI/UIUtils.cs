using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UIUtils
{
    public static void ChangeMenu(GameObject currentMenu, GameObject nextMenu) {
        currentMenu.SetActive(false);
        nextMenu.SetActive(true);
    }
}
