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

    private void Start()
    {
        nameText.text = quest.name;
        descriptionText.text = quest.description;
        iconImage.sprite = quest.icon;
    }
}
