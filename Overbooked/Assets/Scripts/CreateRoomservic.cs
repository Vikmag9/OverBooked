using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CreateRoomservic : MonoBehaviour
{
    private PlayerController controller;
    private InputAction action;
    private AudioSource bellSound;

    private bool makingRoomservic = false;
    private float timer = 0;
    private float endTime = 5;
    public GameObject roomservic;
    public GameObject spawnPoint;
    //int count = 5;

    private Slider timerSlider;
    private void Start()
    {
        
        timerSlider = GameObject.FindWithTag("KitchenUI").gameObject.GetComponentInChildren<Slider>();
        bellSound = GameObject.Find("BellSound").gameObject.GetComponent<AudioSource>();
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
            timer += 1 * Time.deltaTime;
            timerSlider.value = timer;
        }
             
    }

    private void SpawnRoomservic()
    {
        if(timer >= endTime && makingRoomservic)
        {
            Instantiate(roomservic, spawnPoint.transform.position, Quaternion.identity);
            timer = 0;
            timerSlider.value = timer;
            makingRoomservic = false;
            bellSound.Play();
        }
    }
 

}
