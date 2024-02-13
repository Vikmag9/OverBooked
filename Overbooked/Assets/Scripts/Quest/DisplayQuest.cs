using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayQuest : MonoBehaviour
{
    public QuestObjects quest;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;

    public Image iconImage;

    public GameObject questWindow;

    private void Start()
    {
        questWindow.SetActive(false);
        
    }

    public void OpenQuestWindow(QuestObjects quest)
    {
        questWindow.SetActive(true);

        nameText.text = quest.name;
        descriptionText.text = quest.description;
        iconImage.sprite = quest.icon;
    }
}
