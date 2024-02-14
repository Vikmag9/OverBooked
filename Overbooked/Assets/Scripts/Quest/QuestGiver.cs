using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public QuestObjects quest;
    public DisplayQuest questWindow;
    public GameObject bc;
    int perform = 0;
    private bool spawnQuestActive = true;

    public List<QuestObjects> questList;
    public List<BoxCollider> rooms;
    private BoxCollider room;

    public GameManager gm;



    private void Start()
    {
        
        StartCoroutine(SetQuestActive(2f));
    }
    private void Update()
    {
        

        if (quest.isActive == false)
        {
            questWindow.CloseQuestWindow();
        }
    }

    public void DeactivateQuest()
    {
        if (quest.isActive)
        {
            quest.isActive = false;
            spawnQuestActive = true;
            StartCoroutine(SetQuestActive(2f));
            gm.setGold(10);
            perform = 0;
            questWindow.SetSliderValue(perform);
            
        }
        
    }

    private QuestObjects getRandomQuest()
    {
        return questList[Random.Range(0, questList.Count)];
        
    }

    private BoxCollider getRandomRoom()
    {
        return rooms[Random.Range(0, rooms.Count)];
    }

    private void SpawnQuest()
    {
        quest = getRandomQuest();
        room = getRandomRoom();
        quest.isActive = true;
        questWindow.OpenQuestWindow(quest, room.transform.position);


    }

    public IEnumerator SetQuestActive(float waitTime)
    {
        while (spawnQuestActive)
        {
         
            yield return new WaitForSeconds(waitTime);
            Debug.Log("hej");
            SpawnQuest();
            spawnQuestActive = false;
            

        }
        
    }

    public void PerformQuest()
    {
        perform += 1;
        questWindow.SetSliderValue(perform);
        if(perform >= 3)
        {
            DeactivateQuest();
        }
    }

}
