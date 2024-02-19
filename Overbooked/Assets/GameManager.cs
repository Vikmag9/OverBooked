using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private float timeRemaining = 180;
    private float speedUpTime = 60;
    private bool timerIsRunning = false;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI goldText;
    //public Slider timerSlider;
    private int gold = 0;
    // Start is called before the first frame update
    void Start()
    {
        Singelton();
        timerIsRunning = true;
        DisplayGold();
    }

    private GameManager Singelton()
    {
        if (this == null)
        {
            return Instantiate(this);
        }
        else
        {
            return this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
            DisplayTime(timeRemaining);

            if(timeRemaining <= speedUpTime)
            {
                EventManager.current.SpeedUpGame();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        //timerSlider.value = timeToDisplay;


    }

    public void setGold(int amount) { gold += amount; DisplayGold(); }

    void DisplayGold()
    {
        goldText.text = gold.ToString();
    }
}
