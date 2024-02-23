using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private int currentLevel = 0;
    private List<QuestObjects> activeQuests;
    private int life = 3;
    private bool gameOver = false;

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
        //Physics.IgnoreLayerCollision(7, 8);
        
            EventManager.current.playerLoseLife += LoseLife;
            
        
        
    }
    private void Update()
    {
        if(this.transform.position.z <= -2)
        {
            this.transform.position = new Vector3(transform.position.x, transform.position.y, -1.7f);
        }
        
    }

    public void LoseLife()
    {
        
        life -= 1;
        if(life <= 0 )
        {
            gameOver = true;
        }
        
    }



}
