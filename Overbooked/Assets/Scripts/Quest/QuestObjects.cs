using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new card", menuName = "Card")]

public class QuestObjects : ScriptableObject
{
    public string name;
    public string description;

    public Sprite icon;
}
