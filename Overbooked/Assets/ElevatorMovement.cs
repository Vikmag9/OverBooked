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
    
    private InputAction moveElevatorUp;
    private InputAction moveElevatorDown;

    private Vector2 moveDirection;
    private Boolean calledElevator = false;
    private Boolean moveUpAFloor = false;
    private Boolean moveDownAFloor = false;
    private Boolean moving = false;

    public int currentLevel;
    private int beforeLevel;
    private float elevatorSpeed = 100f;

    public ElevatorCall ec;


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
    public void SetCalledElevator(Boolean newInput)
    {
        calledElevator = newInput;
    }

    private void Awake()
    {
        currentLevel = levelList[0].getLevelNumber();
        beforeLevel = currentLevel + 1;
       
    }


    /*private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            moveElevatorUp.performed += context => moveUpAFloor = true;
            moveElevatorDown.performed += context => moveDownAFloor = true;
        }
        
        
    }*/

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            MoveElevatorUp();
        }
    }




    private void Update()
    {
        //if(transform.position.y < levelList[currentLevel + 1].getLevelPos().position.y)
            
        //moveDirection = elevatorInput.ReadValue<Vector2>();
        CallElevator();
        MoveElevatorUp();
        MoveElevatorDown();





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
        if (transform.position.y < levelList[currentLevel].getLevelPos().position.y && moveUpAFloor)
        {
            moving = true;
            transform.Translate(0, 0.01f * elevatorSpeed * Time.deltaTime, 0);
        }

        if (transform.position.y > levelList[currentLevel].getLevelPos().position.y - 0.1f && moveUpAFloor)
        {
            moving = false;
            moveUpAFloor = false;
            //currentLevel += 1;
            transform.position = new Vector3(transform.position.x, levelList[currentLevel].getLevelPos().position.y, transform.position.z);
            ec.MovePlayerOutOfElevator(currentLevel);
            
        }

    }

    void MoveElevatorDown()
    {
        if (transform.position.y > levelList[currentLevel].getLevelPos().position.y)
        {
            moving = true;
            transform.Translate(0, -0.01f * elevatorSpeed * Time.deltaTime, 0);
        }

        if (transform.position.y < levelList[currentLevel].getLevelPos().position.y + 0.1f && moveDownAFloor)
        {
            moving = false;
            moveDownAFloor = false;
            transform.position = new Vector3(transform.position.x, levelList[currentLevel].getLevelPos().position.y, transform.position.y);
            ec.MovePlayerOutOfElevator(currentLevel);
        }

    }

    void CallElevator()
    {

        //Get posistion of player who called the elevator and then decide what way
        //if(ec.getPlayer().GetComponent<PlayerManager>().getPlayerCurrentLevel() < currentLevel)
        if (currentLevel < beforeLevel)
        {
            if(transform.position.y > levelList[currentLevel].getLevelPos().position.y && calledElevator)
            {
                moving = true;
                transform.Translate(0, -0.01f * elevatorSpeed * Time.deltaTime, 0);
            }

            if (transform.position.y - 0.1f <= levelList[currentLevel].getLevelPos().position.y && calledElevator)
            {
                moving = false;
                calledElevator = false;
                ec.MovePlayerInElevator(currentLevel, new Vector3(transform.position.x, transform.position.y, transform.position.z));
                moveUpAFloor = true;
                beforeLevel = currentLevel;
                currentLevel = beforeLevel + 1;
            }
        }
        else
        {
            if (transform.position.y < levelList[currentLevel-1].getLevelPos().position.y && calledElevator)
            {
                moving = true;
                transform.Translate(0, +0.01f * elevatorSpeed * Time.deltaTime, 0);
            }

            if (transform.position.y + 0.1f >= levelList[currentLevel-1].getLevelPos().position.y && calledElevator)
            {
                moving = false;
                calledElevator = false;
                ec.MovePlayerInElevator(currentLevel, new Vector3(transform.position.x, transform.position.y, transform.position.z));
                moveDownAFloor = true;
                currentLevel = beforeLevel;
                beforeLevel = currentLevel + 1;
            }
        }

    }

    

}