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

    public Slider slider;

    private void Start()
    {
        questWindow.SetActive(false);
        
    }

    public void OpenQuestWindow(QuestObjects quest, Vector3 roomPosition)
    {
        
        questWindow.transform.position = new Vector3(roomPosition.x + 2.55f, roomPosition.y + 1, roomPosition.z - 5f);
        questWindow.SetActive(true);
        nameText.text = quest.name;
        descriptionText.text = quest.description;
        iconImage.sprite = quest.icon;

        
    }

    public void CloseQuestWindow() { questWindow.SetActive(false); }

    public void SetSliderValue(float value)
    {
        slider.value = value;
    }
}
