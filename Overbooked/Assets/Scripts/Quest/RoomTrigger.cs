using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RoomTrigger : MonoBehaviour
{
    public PlayerController controller;
    private InputAction questButton;
    private bool inCollider;
    public int id;

    private void Awake()
    {
        controller = new PlayerController();
    }

    private void OnEnable()
    {
        questButton = controller.Player.Quest;
        questButton.Enable();

    }
    private void OnDisable()
    {
        questButton.Disable();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            questButton.Enable();
            questButton.performed += pressedButton;
        }
        if (other.CompareTag("Guest"))
        {
            EventManager.current.RoomGuestTriggerEnter(id);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            questButton.Disable();
            EventManager.current.RoomTriggerExit(id);
        }

        if (other.CompareTag("Guest"))
        {
            EventManager.current.RoomGuestTriggerExit(id);
        }

    }

    private void pressedButton(InputAction.CallbackContext contex) { EventManager.current.RoomTriggerEnter(id); }

}