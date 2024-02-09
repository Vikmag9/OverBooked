using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Assets/Scripts/Quest")]
public class Quest : ScriptableObject
{

    [Header("Basic info")]
    public string questName;
    public string questDescription;
    

    [Header("Quest Rewards")]
    public float coinBaseReward;
    public float coinRewardMultiplier;

    public bool compleded { get; protected set; }

}

public abstract class QuestGoal
{
    protected string description;
    //public GoalType goalType;
    public int requiredAmount = 1;
    public int currentAmount { get; protected set; }

    

}
