using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ElevatorCall : MonoBehaviour
{
    public ElevetorInputMap controller;
    private InputAction callElevator;

    private GameObject player;

    public ElevatorMovement em;

    private void Awake()
    {
        controller = new ElevetorInputMap();

    }

    private void OnEnable()
    {
        callElevator = controller.Elevator.Call;
        callElevator.Enable();
        
    }

    private void OnDisable()
    {
        callElevator.Disable();
    }

    private void OnTriggerStay(Collider other)
    {
        callElevator.performed += context => em.SetCalledElevator(true);
        player = other.gameObject;
        
    }
    private void OnTriggerExit(Collider other)
    {
        player = null;
    }



    public void MovePlayerInElevator(int currentLevel, Vector3 currentPosition)
    {
        if (currentLevel == player.GetComponent<PlayerManager>().getPlayerCurrentLevel())
        {
            player.transform.position = new Vector3(currentPosition.x, currentPosition.y + 1, currentPosition.z);
        }
    }

    public void MovePlayerOutOfElevator(int currentLevel)
    {
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 3f);
        //player.GetComponent<PlayerManager>().setPlayerCurrentLevel(currentLevel);


    }

    public GameObject getPlayer() { return player; }    
}
