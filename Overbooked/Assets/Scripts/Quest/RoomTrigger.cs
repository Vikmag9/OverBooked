using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RoomTrigger : MonoBehaviour
{
    public PlayerController controller;
    private InputAction questButton;
    public GameManager gm;

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
        questButton.performed += pressedButton;
    }

    private void pressedButton(InputAction.CallbackContext contex) { gm.setGold(10); }


}
