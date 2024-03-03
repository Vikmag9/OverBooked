using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ElevatorMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public level[] levelList;
    
    private Boolean calledElevator = false;
    private Boolean moveUpAFloor = false;
    private Boolean moveDownAFloor = false;
    public Boolean moving = false;

    public int currentLevel;
    private int beforeLevel;
    private float elevatorSpeed = 150f;

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

    public void SetUp(Boolean newInput){
        moveUpAFloor = newInput;
    }

    public void SetDown(Boolean newInput){
        moveDownAFloor = newInput;
    }

    private void Awake()
    {
        currentLevel = levelList[0].getLevelNumber();
        beforeLevel = currentLevel + 1;
        //ec = new ElevatorCall();
       
    }



    private void Update()
    {
        //CallElevator();
        MoveElevatorUp();
        MoveElevatorDown();
        



    }


    public void MoveElevatorUp()
    {   if (currentLevel < levelList.Count()-1){
            if (transform.position.y < levelList[currentLevel+1].getLevelPos().position.y && moveUpAFloor)
            {
                ec.MovePlayerInElevator(currentLevel, new Vector3(transform.position.x, transform.position.y, transform.position.z));
                moving = true;
                this.transform.Translate(0, 0.01f * elevatorSpeed * Time.deltaTime, 0);
                //beforeLevel = currentLevel;
                //currentLevel = beforeLevel + 1;
            }

            if (transform.position.y > levelList[currentLevel+1].getLevelPos().position.y - 0.1f && moveUpAFloor)
            {
                moving = false;
                moveUpAFloor = false;
                currentLevel += 1;
                transform.position = new Vector3(transform.position.x, levelList[currentLevel].getLevelPos().position.y, transform.position.z);
                ec.MovePlayerOutOfElevator(currentLevel);
            }
        }

    }

    public void MoveElevatorDown()
    {
        if (currentLevel > levelList[0].levelNumber)
        {
            if (transform.position.y > 0 && moveDownAFloor)
            {
                ec.MovePlayerInElevator(currentLevel, new Vector3(transform.position.x, transform.position.y, transform.position.z));
                moving = true;
                transform.Translate(0, -0.01f * elevatorSpeed * Time.deltaTime, 0);
            }

            if (transform.position.y < levelList[currentLevel - 1].getLevelPos().position.y + 0.1f && moveDownAFloor)
            {
                moving = false;
                moveDownAFloor = false;
                currentLevel -= 1;
                transform.position = new Vector3(transform.position.x, levelList[currentLevel].getLevelPos().position.y, transform.position.z);
                ec.MovePlayerOutOfElevator(currentLevel);
            }
        }
        
            

    }

    void CallElevator()
    {
        /*if(ec.getPlayer().GetComponent<PlayerManager>().getPlayerCurrentLevel() != currentLevel) 
        {
            if (currentLevel < beforeLevel)
            {
                if (transform.position.y > levelList[currentLevel].getLevelPos().position.y && calledElevator)
                {
                    moving = true;
                    transform.Translate(0, -0.01f * elevatorSpeed * Time.deltaTime, 0);
                }

                if (transform.position.y - 0.1f <= levelList[currentLevel].getLevelPos().position.y && calledElevator)
                {
                    moving = false;
                    calledElevator = false;
                    moveUpAFloor = true;
                    beforeLevel = currentLevel;
                    currentLevel = beforeLevel + 1;
                    
                }
            }

            else
            {
                if (transform.position.y < levelList[currentLevel - 1].getLevelPos().position.y && calledElevator)
                {
                    moving = true;
                    transform.Translate(0, +0.01f * elevatorSpeed * Time.deltaTime, 0);
                }

                if (transform.position.y + 0.1f >= levelList[currentLevel - 1].getLevelPos().position.y && calledElevator)
                {
                    moving = false;
                    calledElevator = false;
                    moveDownAFloor = true;
                    currentLevel = beforeLevel;
                    beforeLevel = currentLevel + 1;
                }
            }
        }
        else
        {*/

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
                moveUpAFloor = true;
                ec.MovePlayerInElevator(currentLevel, new Vector3(transform.position.x, transform.position.y, transform.position.z));
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
                moveDownAFloor = true;
                ec.MovePlayerInElevator(currentLevel, new Vector3(transform.position.x, transform.position.y, transform.position.z));
                currentLevel = beforeLevel;
                beforeLevel = currentLevel + 1;
                
                }
            }
        }

    //}

    

}