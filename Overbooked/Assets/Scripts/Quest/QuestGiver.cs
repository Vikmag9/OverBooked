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

    public int id;



    private void Start()
    {
      
        StartCoroutine(SetQuestActive(2f));
        EventManager.current.onRoomEnter += PerformQuest;
        
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
        perform = 0;
        questWindow.SetSliderValue(perform);
        quest.isActive = true;
        quest.roomId = room.GetComponent<RoomTrigger>().id;
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

    public void PerformQuest(int id)
    {
        this.id = id;
        if (id == this.id && id == quest.roomId)
        {
            
            perform += 1;
            questWindow.SetSliderValue(perform);
            if (perform >= 3)
            {
                DeactivateQuest();
            }
        }
        
    }

}
