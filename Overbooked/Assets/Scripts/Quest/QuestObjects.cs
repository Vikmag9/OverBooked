using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "new card", menuName = "Card")]

public class QuestObjects : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite icon;
    public QuestGoal type;

    public bool isActive;
    public int roomId;
}
