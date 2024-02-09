using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Quest", menuName = "Quest")];

public class Quest : ScriptableObject
{

    [Header("Basic info")]
    public string questName;
    public string questDescription;

    [Header("Quest Rewards")]
    public float coinBaseReward;
    public float coinRewardMultiplier;

    [Header("Quest Goals")]
    public bool isActive;    {
        return (currentAmount >= requiredAmount);
    }
    public void ItemCollected()
    {
        if (goalType == GoalType.Gather)
        {
            currentAmount++;
        }
    }
    public void ItemDelivered()
    {
        if (goalType == GoalType.Deliver)
        {
            currentAmount++;
        }
    }
    
    public void Deactivate()
    {
        isActive = false;
    }

}

public class QuestGoal
{
    protected string description;
    public GoalType goalType;
    public int requiredAmount;
    public int currentAmount;

    public BoxCollider roomCollider;

}
