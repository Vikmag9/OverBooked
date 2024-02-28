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
    private float questTimer = 20f;
    private int id;

    private bool clean;
    private bool roomservic;

    void Start()
    {
        
        questManager = GameObject.Find("Quest Manager").GetComponent<QuestGiver>();
        questCanvas = this.gameObject.transform.GetChild(transform.childCount - 1).gameObject;
        questWindowInRoom = this.GetComponent<DisplayQuest>();
        questWindowInRoom.CloseQuestWindow();
        SpawnQuest();
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
                //questWindowInRoom.CloseQuestWindow();
            }
        }
    }

    private void SpawnQuest()
    {
        
        questInRoom = questManager.getRandomQuest();
        performQuest = 0;
        questInRoom.timer = questTimer;
        questWindowInRoom.OpenQuestWindow(questInRoom);

    }

    private void CountDownQuestTimer()
    {
        questInRoom.timer -= 1f * Time.deltaTime;
        questWindowInRoom.SetSliderValue(questInRoom.timer);

        if (questInRoom.timer <= 0)
        {
            //if (quest.isActive)
            
                questManager.DeactivateQuest(0);
            //EventManager.current.LoseLife();
            EventManager.current.LoseLife();
            questInRoom.timer = 10000000000;

        }
    }

    public void PerformQuest(int id)
    {
        this.id = id;
        if (id == this.id && id == roomId && CheckRequirements())
        {

            performQuest += 1;
            if (performQuest >= 3)
            {
                questManager.DeactivateQuest(10);
                questManager.completeQuestSound.Play();
                EventManager.current.QuestDeactive();
            }
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
    public bool CheckRequirements()
    {
        if (questInRoom.type.goalType == GoalType.Clean && clean)
        {
            return true;
        }
        else if (questInRoom.type.goalType == GoalType.Roomservice && roomservic)
        {
            return true;
        }
        return false;
    }

}
