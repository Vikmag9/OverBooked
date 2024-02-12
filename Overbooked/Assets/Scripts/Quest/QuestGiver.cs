﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    // public Player player;

    public GameObject questWindow;
    public Text titleText;
    public Text descriptionText;
    public Text experienceText;
    public Text goldText;


    public void OpenQuestWindow()
    {
        questWindow.SetActive(false);
    }
}