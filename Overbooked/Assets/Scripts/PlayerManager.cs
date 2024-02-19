using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private int currentLevel = 0;
    private List<QuestObjects> activeQuests;

    public int getPlayerCurrentLevel()
    {
        return this.currentLevel;
    }

    public void setPlayerCurrentLevel(int newLevel)
    {
        this.currentLevel = newLevel;
    }

    private void Start()
    {
        Physics.IgnoreLayerCollision(7, 8);
    }



}
