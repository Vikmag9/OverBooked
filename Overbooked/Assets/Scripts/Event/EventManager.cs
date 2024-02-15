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

}