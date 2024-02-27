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

    private bool clean;
    private bool roomservic;

    private AudioSource completeQuestSound;

    private int currentRoomID;



    private void Start()
    {
      
        StartCoroutine(SetQuestActive(2f));
        completeQuestSound = GameObject.Find("CompleteQuestSound").GetComponent<AudioSource>();
        EventManager.current.onRoomEnter += PerformQuest;
        EventManager.current.pickedUpCleaningItem += HoldingCleaningItem;
        EventManager.current.pickedUpRoomservicItem += HoldingRoomservicItem;
        EventManager.current.droppedItem += DroopingItem;
        
        
    }

    private void Current_pickedUpCleaningItem()
    {
        throw new System.NotImplementedException();
    }

    private void Update()
    {
        
        if(quest != null)
        {
           CountDownQuestTimer();
            if (quest.isActive == false)
            {
                questWindow.CloseQuestWindow();
                EventManager.current.QuestDeactive();

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
        
        this.currentRoomID = room.GetComponent<RoomTrigger>().id;
        EventManager.current.QuestActive();


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
        if (id == this.id && id == quest.roomId && CheckRequirements())
        {
            
            perform += 1;

            float remainingTimePercentage = quest.timer / questTimer;

            // Kolla vilken belöningsnivå som ska tilldelas baserat på tidsåterstående
            int reward;
            if (remainingTimePercentage > 2f / 3f) // Över 2/3 av tiden kvar
            {
                reward = 10;
            }
            else if (remainingTimePercentage > 1f / 3f) // Mindre än 2/3 men mer än 1/3 av tiden kvar
            {
                reward = 5;
            }
            else // Mindre än 1/3 av tiden kvar
            {
                reward = 2;
            }

            // Uppdatera belöningen för questen
            //DeactivateQuest(reward);
            
            if (perform >= 3)
            {
                DeactivateQuest(reward);
                completeQuestSound.Play();
                //EventManager.current.QuestDeactive();
            }
        }
        
    }

    private void CountDownQuestTimer()

    {
        quest.timer -= 1f;
        questWindow.SetSliderValue(quest.timer);

        if(quest.timer <= 0)
        {
            DeactivateQuest(0);
            //EventManager.current.LoseLife();
            EventManager.current.LoseLife();
            quest.timer = 10000000000;

        }
    }


    private void HoldingCleaningItem()
    {
        clean = true;
    }

    private void HoldingRoomservicItem()
    {
        roomservic = true;
    }
    private void DroopingItem()
    {
        clean = false;
        roomservic = false;
    }

    private bool CheckRequirements()
    {
        if(quest.type.goalType == GoalType.Clean && clean)
        {
            return true;
        }
        else if(quest.type.goalType == GoalType.Roomservice && roomservic)
        {
            return true;
        }
        return false;
    }

    public int getRoomID()
    {
        return currentRoomID;
    }
}
