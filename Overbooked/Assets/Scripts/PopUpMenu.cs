using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpMenu : MonoBehaviour
{
    public Canvas popCanvas;
    public bool active = false;
    public static event Action<bool> popUpMenuActive;

    public void Start()
    {
        popCanvas.enabled = false;
    }
    public void popup()
    {
        active = !active;
        popCanvas.enabled = active;

        popUpMenuActive?.Invoke(active);
    }
}
