using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RoomTrigger : MonoBehaviour
{
    public PlayerController controller;
    private InputAction questButton;
    public GameManager gm;
    public QuestGiver qg;
    private bool inCollider;

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

    void Update()
    {

        if (inCollider)
        {
            //questButton.performed += pressedButton;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inCollider = true;
            questButton.Enable();
            questButton.performed += pressedButton;
        }
        

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inCollider = false;
            questButton.Disable();
        }

    }

    private void pressedButton(InputAction.CallbackContext contex) { qg.PerformQuest(); }

}