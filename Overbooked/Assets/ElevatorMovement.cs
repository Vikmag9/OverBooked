using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ElevatorMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public level[] levelList;
    public ElevetorInputMap controller;
    private InputAction elevatorInput;
    private InputAction callElevator;

    private Vector2 moveDirection;

    public int currentLevel;
    private float elapsedTime = 0f;
    private float duration = 10F;
    private float elevatorSpeed = 75;

    [Serializable]
    public struct level
    {
        public Transform levelPos;
        public int levelNumber;

        public int getLevelNumber()
        {
            return levelNumber;
        }

        public Transform getLevelPos()
        {
            return levelPos;
        }

    }

    private void Awake()
    {
        controller = new ElevetorInputMap();
        currentLevel = levelList[0].getLevelNumber();
        

    }

    private void OnEnable()
    {
        elevatorInput = controller.Elevator.MoveElevator;
        callElevator = controller.Elevator.Call;

        elevatorInput.Enable();
        callElevator.Enable();
        
    }

    private void OnDisable()
    {
        elevatorInput.Disable();
        callElevator.Disable();
    }
    private void OnTriggerStay(Collider other)
    {
        moveElevator();
    }

    private void Update()
    {
        //if(transform.position.y < levelList[currentLevel + 1].getLevelPos().position.y)
            
        moveDirection = elevatorInput.ReadValue<Vector2>();


        
    }

    void moveElevator()
    {
        transform.Translate(0, moveDirection.y * 0.01f * elevatorSpeed * Time.deltaTime, 0);
    }



}
