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
            questButton.performed += pressedButton;
            Debug.Log(questButton.performed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        inCollider = true;
        
    }

    private void OnTriggerExit(Collider other)
    {
        inCollider = false;
        
    }

    private void pressedButton(InputAction.CallbackContext contex) { gm.setGold(10); qg.DeactivateQuest(); }


}
