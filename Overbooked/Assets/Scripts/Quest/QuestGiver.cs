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
    private float questTimer = 20f;

    private bool clean;
    private bool roomservic;

    public AudioSource completeQuestSound;

    private int currentRoomID;



    private void Start()
    {
      
        StartCoroutine(SetQuestActive(2f));
        completeQuestSound = GameObject.Find("CompleteQuestSound").GetComponent<AudioSource>();
        //EventManager.current.onRoomEnter += PerformQuest;
        /*EventManager.current.pickedUpCleaningItem += HoldingCleaningItem;
        EventManager.current.pickedUpRoomservicItem += HoldingRoomservicItem;
        EventManager.current.droppedItem += DroopingItem;
        Debug.Log(questList.Count);*/
        
        
    }

    private void Current_pickedUpCleaningItem()
    {
        throw new System.NotImplementedException();
    }

    private void Update()
    {
        
        /*if(quest != null)
        {
           //CountDownQuestTimer();
            if (quest.isActive == false)
            {
                questWindow.CloseQuestWindow();
            }
        }*/
        
    }

    public void DeactivateQuest(int gold)
    {
        
            //quest.isActive = false;
            spawnQuestActive = true;
            StartCoroutine(SetQuestActive(2f));
            gm.setGold(gold);

        
        
    }

    public QuestObjects getRandomQuest()
    {
        QuestObjects getRandomQuest = questList[Random.Range(0, questList.Count)];
        QuestObjects copyOfObject = Instantiate(getRandomQuest);
        return copyOfObject;
        
    }

    private BoxCollider getRandomRoom()
    {
        return rooms[Random.Range(0, rooms.Count)];
    }

    /*private void SpawnQuest()
    {

        quest = getRandomQuest();
        room = getRandomRoom();
        perform = 0;
        //questWindow.SetSliderValue(perform);
        quest.isActive = true;
        quest.timer = questTimer;
        quest.roomId = room.GetComponent<RoomTrigger>().id;
        questWindow.OpenQuestWindow(quest);
        
        this.currentRoomID = room.GetComponent<RoomTrigger>().id;
        EventManager.current.QuestActive();


    }*/

    public IEnumerator SetQuestActive(float waitTime)
    {
        while (spawnQuestActive)
        {
         
            yield return new WaitForSeconds(waitTime);
            //SpawnQuest();
            spawnQuestActive = false;
            
        }
        
    }

    /*public void PerformQuest(int id)
    {
        this.id = id;
        if (id == this.id && id == quest.roomId && CheckRequirements())
        {
            
            perform += 1;
            if (perform >= 3)
            {
                DeactivateQuest(10);
                completeQuestSound.Play();
                EventManager.current.QuestDeactive();
            }
        }
        
    }*/

    /*private void CountDownQuestTimer()
    {
        quest.timer -= 1f * Time.deltaTime;
        questWindow.SetSliderValue(quest.timer);

        if(quest.timer <= 0)
        {
            DeactivateQuest(0);
            //EventManager.current.LoseLife();
            EventManager.current.LoseLife();
            quest.timer = 10000000000;

        }
    }*/


    /*private void HoldingCleaningItem()
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

    public bool CheckRequirements()
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
*/
    public int getRoomID()
    {
        return currentRoomID;
    }
}
