using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CreateRoomservic : MonoBehaviour
{
    private PlayerController controller;
    private InputAction action;

    private bool makingRoomservic = false;
    private float timer = 0;
    private float endTime = 3;
    public GameObject roomservic;
    public GameObject spawnPoint;
    //int count = 5;

    private Slider timerSlider;
    private void Start()
    {
        
        timerSlider = GameObject.FindWithTag("KitchenUI").gameObject.GetComponentInChildren<Slider>();
    }

    private void Awake()
    {
        controller = new PlayerController();
    }

    private void OnEnable()
    {
        action = controller.Player.Quest;
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    void Update()
    {
        timerSlider.value = timer;
        CountUpTimer();
        SpawnRoomservic();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !makingRoomservic)
        {
            action.Enable();
            action.performed += StartTimer;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        action.Disable();
    }

    private void StartTimer(InputAction.CallbackContext contex)
    {
        action.Disable();
        makingRoomservic = true;
         
    }

    private void CountUpTimer()
    {
        if(makingRoomservic && timer <= endTime)
        {
            timer += 1* Time.deltaTime;
        }
             
    }

    private void SpawnRoomservic()
    {
        if(timer >= endTime && makingRoomservic)
        {
            Instantiate(roomservic, spawnPoint.transform.position, Quaternion.identity);
        }
    }
 

}
