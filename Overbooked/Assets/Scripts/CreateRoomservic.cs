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
    private float timer = 0f;
    private float endTime = 1000f;
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
        makingRoomservic = true;
        CountUpTimer();
        
    }

    private void CountUpTimer()
    {
        while(timer <= endTime)
        {
            timer += 0.00001f ;
        }
        
    }
 

}
