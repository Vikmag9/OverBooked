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

    private bool spawnQuestActive = true;
    private bool clean;
    private bool roomservic;

    void Start()
    {
        
        questManager = GameObject.Find("Quest Manager").GetComponent<QuestGiver>();
        questCanvas = this.gameObject.transform.GetChild(transform.childCount - 1).gameObject;
        questWindowInRoom = this.GetComponent<DisplayQuest>();
        questWindowInRoom.CloseQuestWindow();
        StartCoroutine(SetQuestActive(UnityEngine.Random.Range(1f, 5f)));
        //SpawnQuest();
        EventManager.current.onRoomEnter += PerformQuest;
        EventManager.current.pickedUpCleaningItem += HoldingCleaningItem;
        EventManager.current.pickedUpRoomservicItem += HoldingRoomservicItem;
        EventManager.current.droppedItem += DroopingItem;

    }

    // Update is called once per frame
    void Update()
    {
        if (questInRoom != null)
        {
            CountDownQuestTimer();
            if (questInRoom.isActive == false)
            {
                questWindowInRoom.CloseQuestWindow();
            }
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
                Debug.Log("Du är i rummet och utför en quest");
                this.questInRoom.isActive = false;
                //DeactivateQuest(10, id);
                questManager.completeQuestSound.Play();
                EventManager.current.QuestDeactive();
            }
        }

    }
    public void DeactivateQuest(int gold, int id)
    {
        if(roomId == id)
        {
            this.questInRoom.isActive = false;
            //spawnQuestActive = true;
            //StartCoroutine(SetQuestActive(2f));
            questManager.gm.setGold(gold);
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
