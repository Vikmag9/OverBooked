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
    private InputAction moveElevatorUp;
    private InputAction moveElevatorDown;

    private Vector2 moveDirection;
    private Boolean calledElevator = false;
    private Boolean moveUpAFloor = false;
    private Boolean moveDownAFloor = false;

    public int currentLevel;
    private float elevatorSpeed = 100f;



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
        moveElevatorUp = controller.Elevator.MoveElevatorUp;
        moveElevatorDown = controller.Elevator.MoveElevatorDown;

        elevatorInput.Enable();
        callElevator.Enable();
        moveElevatorUp.Enable();
        moveElevatorDown.Enable();

        callElevator.performed += context => calledElevator = true;


    }

    private void OnDisable()
    {
        elevatorInput.Disable();
        callElevator.Disable();
        moveElevatorUp.Disable();
        moveElevatorDown.Disable();
    }
    private void OnTriggerStay(Collider other)
    {
        moveElevatorUp.performed += context => moveUpAFloor = true;
        moveElevatorDown.performed += context => moveDownAFloor = true;
        
    }
    private void OnTriggerExit(Collider other) 
    {
        moveElevatorUp.canceled += context => moveUpAFloor = false;
        moveElevatorDown.canceled += context => moveDownAFloor = false;
    }

    private void Update()
    {
        //if(transform.position.y < levelList[currentLevel + 1].getLevelPos().position.y)
            
        moveDirection = elevatorInput.ReadValue<Vector2>();
        CallElevator();
        MoveElevatorUp();
        MoveElevatorDown();

        if (moveUpAFloor)
        {
            moveDownAFloor = false;
            calledElevator = false;
        }
        if (moveDownAFloor)
        {
            moveUpAFloor = false;
            calledElevator = false;
        }
        if (calledElevator)
        {
            moveUpAFloor = false;
            moveDownAFloor = false;
        }



    }

    /*void MoveElevator()
    {
        if(transform.position.y < levelList[currentLevel+1].getLevelPos().position.y){ 
        transform.Translate(0, moveDirection.y * 0.01f * elevatorSpeed * Time.deltaTime, 0);
        }

        if(transform.position.y > levelList[currentLevel + 1].getLevelPos().position.y-0.1f)
        {
            transform.position = new Vector3(0, levelList[currentLevel + 1].getLevelPos().position.y, 0);
        }


    }*/

    void MoveElevatorUp()
    {
        if (transform.position.y < levelList[currentLevel + 1].getLevelPos().position.y && moveUpAFloor)
        {
            transform.Translate(0, 0.01f * elevatorSpeed * Time.deltaTime, 0);
        }

        if (transform.position.y > levelList[currentLevel + 1].getLevelPos().position.y - 0.1f && moveUpAFloor)
        {
            moveUpAFloor = false;
            transform.position = new Vector3(0, levelList[currentLevel + 1].getLevelPos().position.y, 0);
            
        }

    }

    void MoveElevatorDown()
    {
        if (transform.position.y > levelList[currentLevel].getLevelPos().position.y && moveDownAFloor)
        {
            transform.Translate(0, -0.01f * elevatorSpeed * Time.deltaTime, 0);
        }

        if (transform.position.y < levelList[currentLevel].getLevelPos().position.y + 0.1f && moveDownAFloor)
        {
            moveDownAFloor = false;
            transform.position = new Vector3(0, levelList[currentLevel].getLevelPos().position.y, 0);
            
        }

    }

    void CallElevator()
    {
        //Get posistion of player who called the elevator and then decide what way
        if(transform.position.y > levelList[currentLevel].getLevelPos().position.y && calledElevator)
        {
            transform.Translate(0, -0.01f * elevatorSpeed * Time.deltaTime, 0);
        }

        if (transform.position.y - 0.1f <= levelList[currentLevel].getLevelPos().position.y && calledElevator)
        {
            calledElevator = false;
        }
        
    }

}