using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager current;

    private void Awake()
    {
        current = this;
    }

    public event Action<int> onRoomEnter;
    public void RoomTriggerEnter(int id)
    {
        if (onRoomEnter != null)
        {
            onRoomEnter(id);
        }
    }

    public event Action<int> onRoomExit;
    public void RoomTriggerExit(int id)
    {
        if (onRoomExit != null)
        {
            onRoomExit(id);
        }
    }

    public event Action pickedUpCleaningItem;
    public void PickedUpCleaningItem()
    {
        if(pickedUpCleaningItem != null)
        {
            pickedUpCleaningItem();
        }
    }
    public event Action pickedUpRoomservicItem;
    public void PickedUpRoomservicItem()
    {
        if (pickedUpRoomservicItem != null)
        {
            pickedUpRoomservicItem();
        }
    }

    public event Action droppedItem;
    public void DroppedItem()
    {
        if (droppedItem != null)
        {
            droppedItem();
        }
    }

    public event Action littleTimeLeft;
    public void SpeedUpGame()
    {
        if(littleTimeLeft != null)
        {
            littleTimeLeft();
        }
    }

    public event Action questActive;
    public void QuestActive()
    {
        if(questActive != null)
        {
            questActive();
        }
    }

    public event Action questDeactive;
    public void QuestDeactive()
    {
        if(questDeactive != null)
        {
            questDeactive();
        }
    }

}