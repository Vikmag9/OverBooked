using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[System.Serializable]
public class Quest
{
    public bool isActive;
    public string title;
    public string description;
    public int experiencereward;
    public int goldreward;
}
