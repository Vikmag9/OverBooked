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
    private float questTimer = 1000f;



    private void Start()
    {
      
        StartCoroutine(SetQuestActive(2f));
        EventManager.current.onRoomEnter += PerformQuest;
        
    }
    private void Update()
    {
        
        if(quest != null)
        {
           CountDownQuestTimer();
            if (quest.isActive == false)
            {
                questWindow.CloseQuestWindow();
            }
        }
        
    }

    public void DeactivateQuest(int gold)
    {
        if (quest.isActive)
        {
            quest.isActive = false;
            spawnQuestActive = true;
            StartCoroutine(SetQuestActive(2f));
            gm.setGold(gold);

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
        quest.timer = questTimer;
        quest.roomId = room.GetComponent<RoomTrigger>().id;
        questWindow.OpenQuestWindow(quest, room.transform.position);


    }

    public IEnumerator SetQuestActive(float waitTime)
    {
        while (spawnQuestActive)
        {
         
            yield return new WaitForSeconds(waitTime);
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
            if (perform >= 3)
            {
                DeactivateQuest(10);
            }
        }
        
    }

    private void CountDownQuestTimer()
    {
        quest.timer -= 1f;
        questWindow.SetSliderValue(quest.timer);

        if(quest.timer <= 0)
        {
            DeactivateQuest(-10);
        }
    }

}
