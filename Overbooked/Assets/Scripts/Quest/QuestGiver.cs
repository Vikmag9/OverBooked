using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public QuestObjects quest;
    public DisplayQuest questWindow;
    public GameObject bc;

    public List<QuestObjects> questList;

    private int timer = 100;


    private void Start()
    {
        
        quest = questList[Random.Range(0, questList.Count)];
        quest.isActive = true;
    }
    private void Update()
    {
        timer--;
        if(timer <= 0)
        {
            
            questWindow.OpenQuestWindow(quest, bc.transform.position);
        }

        if (quest.isActive == false)
        {
            questWindow.CloseQuestWindow();
        }
    }

    public void DeactivateQuest()
    {
        quest.isActive = false;
    }
}
