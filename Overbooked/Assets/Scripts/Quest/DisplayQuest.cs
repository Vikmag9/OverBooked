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
    public Slider completeSlider;

    public bool completeSliderActive = false;

    private void Start()
    {
        //this.questWindow.SetActive(false);
        
    }

    public void OpenQuestWindow(QuestObjects quest)
    {
        
        //questWindow.transform.position = new Vector3(roomPosition.x + 2.55f, roomPosition.y + 1, roomPosition.z - 5f);
        this.questWindow.SetActive(true);
        this.nameText.text = quest.name;
        //descriptionText.text = quest.description;
        this.iconImage.sprite = quest.icon;
        this.completeSlider.gameObject.SetActive(false);
        completeSliderActive = false;
    }

    public void CloseQuestWindow() { this.questWindow.SetActive(false); }

    public void SetSliderValue(float value)
    {
        this.slider.value = value;
    }

    public void SetCompleteSliderValue(float value)
    {
        if (completeSliderActive) // Visa complete slider bara om den är aktiv
        {
            this.completeSlider.value = value;
        }
    }

}
