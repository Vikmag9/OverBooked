using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public QuestObjects quest;
    public DisplayQuest questWindow;
    public GameObject bc;
    private bool spawnQuestActive = true;

    public List<QuestObjects> questList;



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
        quest.isActive = false;
        spawnQuestActive = true;
        StartCoroutine(SetQuestActive(2f));

    }

    private QuestObjects getRandomQuest()
    {
        return questList[Random.Range(0, questList.Count)];
        
    }

    private void SpawnQuest()
    {
        quest = getRandomQuest();
        quest.isActive = true;
        questWindow.OpenQuestWindow(quest, bc.transform.position);


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

}
