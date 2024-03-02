using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public QuestObjects quest;
    public List<QuestObjects> questList;
   

    public GameManager gm;

    public int id;


    public AudioSource completeQuestSound;
    public AudioSource FailureSound;

    private int currentRoomID;



    private void Start()
    {
        completeQuestSound = GameObject.Find("CompleteQuestSound").GetComponent<AudioSource>();
        
    }

    public QuestObjects getRandomQuest()
    {
        QuestObjects getRandomQuest = questList[Random.Range(0, questList.Count)];
        QuestObjects copyOfObject = Instantiate(getRandomQuest);
        return copyOfObject;
        
    }

    public int getRoomID()
    {
        return currentRoomID;
    }
}
