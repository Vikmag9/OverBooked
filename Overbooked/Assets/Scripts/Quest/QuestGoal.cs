using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public int requiredAmount;
    public int currentAmount;
    public GoalType goalType;

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }
}

public enum GoalType
{
    Clean,
    Roomservice
}
