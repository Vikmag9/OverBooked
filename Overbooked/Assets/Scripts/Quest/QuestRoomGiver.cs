using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestRoomGiver : MonoBehaviour
{
    // Start is called before the first frame update

    private QuestGiver questManager;
    private QuestObjects questInRoom;
    
    public int roomId;
    private GameObject questCanvas;
    private DisplayQuest questWindowInRoom;
    private int performQuest;
    private float questTimer = 40f;
    private bool timerIsRunning = true;

    private bool spawnQuestActive = true;
    private bool clean;
    private bool roomservic;

    private bool guestInRoom = false;
    private bool canSpawnQuest = true;



    void Start()
    {
        
        questManager = GameObject.Find("Quest Manager").GetComponent<QuestGiver>();
        questCanvas = this.gameObject.transform.GetChild(transform.childCount - 1).gameObject;
        questWindowInRoom = this.GetComponent<DisplayQuest>();
        questWindowInRoom.CloseQuestWindow();
        
        //SpawnQuest();
        EventManager.current.onRoomEnter += PerformQuest;
        EventManager.current.pickedUpCleaningItem += HoldingCleaningItem;
        EventManager.current.pickedUpRoomservicItem += HoldingRoomservicItem;
        EventManager.current.droppedItem += DroopingItem;
        EventManager.current.onRoomGuestEnter += GuestInRoom;

        PopUpMenu.popUpMenuActive += HandlePopUpMenuState;

        //StartCoroutine(SetQuestActive(UnityEngine.Random.Range(1f, 5f)));

    }

    private void HandlePopUpMenuState(bool isActive)
    {
        timerIsRunning = !isActive;
    }




    private void GuestInRoom(int id)
    {
        if(id == roomId)
        {
            guestInRoom = true;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (questInRoom != null)
        {
            if (timerIsRunning == true)
            {
                CountDownQuestTimer();
                if (questInRoom.isActive == false)
                {
                    questWindowInRoom.CloseQuestWindow();
                }
            }
        }

        if (guestInRoom && canSpawnQuest)
        {
            StartCoroutine(SetQuestActive(UnityEngine.Random.Range(1f, 5f)));
            canSpawnQuest = false;
            
        }


    }

    private void SpawnQuest()
    {
        
        questInRoom = questManager.getRandomQuest();
        performQuest = 0;
        questInRoom.timer = questTimer;
        questInRoom.isActive = true;
        questWindowInRoom.OpenQuestWindow(questInRoom);

    }

    private void CountDownQuestTimer()
    {
        questInRoom.timer -= 1f * Time.deltaTime;
        questWindowInRoom.SetSliderValue(questInRoom.timer);

        if (questInRoom.timer <= 0)
        {
            //if (quest.isActive)
            Debug.Log("hsfjsjfop");
            questWindowInRoom.CloseQuestWindow();
            questManager.DeactivateQuest(0);
            //EventManager.current.LoseLife();
            EventManager.current.LoseLife();
            questInRoom.timer = 10000000000;

        }
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
        
        if (id == roomId && CheckRequirements(id))
        {
            
            performQuest += 1;
            if (performQuest >= 3)
            {
                Debug.Log("Du ?r i rummet och utf?r en quest");
                this.questInRoom.isActive = false;
                DeactivateQuest(10);
                questManager.completeQuestSound.Play();
                EventManager.current.QuestDeactive();
            }
        }

    }
    public void DeactivateQuest(int gold)
    {
       
        
            this.questInRoom.isActive = false;
            spawnQuestActive = true;
            canSpawnQuest = true;
            //StartCoroutine(SetQuestActive(2f));
            questManager.gm.setGold(gold);
        

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
    public bool CheckRequirements(int id)
    {
        if (this.questInRoom.type.goalType == GoalType.Clean && clean)
        {
            return true;
        }
        else if (this.questInRoom.type.goalType == GoalType.Roomservice && roomservic)
        {
            return true;
        }
        return false;
    }

    private void OnDestroy()
    {
        EventManager.current.onRoomEnter -= PerformQuest;
    }

    private Func<List<GameObject>> onRequestListOfRooms;
    public void SetOnRequestListOfRooms(Func<List<GameObject>> returnEvent)
    {
        onRequestListOfRooms = returnEvent;
    }

    public List<GameObject> RequestListOfRooms()
    {
        if(onRequestListOfRooms != null)
        {
            return onRequestListOfRooms();
        }
        return null;
    }
}
