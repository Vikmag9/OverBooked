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
    private int performQuest = 0;
    private float questTimer = 40f;
    private bool timerIsRunning = true;

    private bool spawnQuestActive = true;
    private bool clean;
    private bool roomservic;
    private bool answerThePhone = true;

    private bool guestInRoom = false;
    private bool canSpawnQuest = true;

    public bool specialRoom;
    public List<QuestObjects> specialQuests;

    public AudioSource phoneSound;



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

    private void CheckSpecialRoom()
    {
        if (specialRoom)
        {
            questInRoom = GetSpecialQuest();
        }
        else
        {
            questInRoom = questManager.getRandomQuest();
        }
    }

    private QuestObjects GetSpecialQuest()
    {
        return specialQuests[UnityEngine.Random.Range(0, specialQuests.Count)];
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

        if (guestInRoom && canSpawnQuest || specialRoom && canSpawnQuest)
        {
            StartCoroutine(SetQuestActive(UnityEngine.Random.Range(5f, 30f)));
            canSpawnQuest = false;
            
        }


    }

    private void SpawnQuest()
    {

        //questInRoom = questManager.getRandomQuest();
        CheckSpecialRoom();
        performQuest = 0;
        questInRoom.timer = questTimer;
        questInRoom.isActive = true;
        //questWindowInRoom.SetCompleteSliderValue(performQuest);
        questWindowInRoom.OpenQuestWindow(questInRoom);

        if(questInRoom.type.goalType == GoalType.Special)
        {
            phoneSound.Play();
        }

    }

    private void CountDownQuestTimer()
    {
        questInRoom.timer -= Time.deltaTime;
        questWindowInRoom.SetSliderValue(questInRoom.timer);

        if (questInRoom.timer <= 0 && questInRoom.isActive)
        {
            questWindowInRoom.CloseQuestWindow();
            EventManager.current.LoseLife();
            questManager.FailureSound.Play();
            questInRoom.timer = 10000000000;
        }
    }
    /*
    private void CountDownQuestTimer()
    {
        questInRoom.timer -= 1f * Time.deltaTime;
        questWindowInRoom.SetSliderValue(questInRoom.timer);

        if (questInRoom.timer <= 0)
        {
            //if (quest.isActive)
            
            questWindowInRoom.CloseQuestWindow();
            DeactivateQuest(0);
            //EventManager.current.LoseLife();
            EventManager.current.LoseLife();
            questManager.FailureSound.Play();
            questInRoom.timer = 10000000000;

        }
    }
    */
    public IEnumerator SetQuestActive(float waitTime)
    {
        while (spawnQuestActive)
        {

            yield return new WaitForSeconds(waitTime);
            SpawnQuest();
            answerThePhone = true;
            spawnQuestActive = false;
            EventManager.current.onRoomEnter += PerformQuest;


        }

    }

    public void PerformQuest(int id)
    {
        
        if (id == roomId && CheckRequirements(id))
        {
            questWindowInRoom.completeSlider.gameObject.SetActive(true);
            questWindowInRoom.completeSliderActive = true;

            performQuest = performQuest + 1;
            questWindowInRoom.SetCompleteSliderValue(performQuest);
            if (performQuest >= 6)
            {
                float remainingTimePercentage = this.questInRoom.timer / questTimer;
                int reward;

                if (remainingTimePercentage > 2f / 3f) 
                {
                    reward = 10;
                }
                else if (remainingTimePercentage > 1f / 3f)  
                {
                    reward = 5;
                }
                else 
                {
                    reward = 2;
                }
                performQuest = 0;
                flag = 0;
                //this.questInRoom.isActive = false;
                
                questManager.completeQuestSound.Play();
                DeactivateQuest(reward);


                if (questInRoom.type.goalType == GoalType.Special)
                {
                    phoneSound.Pause();
                }
                EventManager.current.QuestDeactive();
                EventManager.current.onRoomEnter -= PerformQuest;


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
            answerThePhone = false;
            performQuest = -1;
        

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
        else if(this.questInRoom.type.goalType == GoalType.Special && answerThePhone)
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
