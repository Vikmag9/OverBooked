using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float timeRemaining = 70;
    private float speedUpTime = 60;
    private bool timerIsRunning = false;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI goldText;
    private int gold = 0;
    public List<Image> heartImages;
    private int lifesLeft = 3;

    //text
    private Color normalTextColor;
    private Vector3 normalTextScale;
    private Vector3 normalTextPosition;
    private int countNr = 0;

    // Start is called before the first frame update
    void Start()
    {

        normalTextColor = timerText.color;
        normalTextScale = timerText.transform.localScale;
        normalTextPosition = timerText.transform.localPosition;

        Singelton();
        timerIsRunning = true;
        DisplayGold();
        EventManager.current.playerLoseLife += DisableHeart;
        PopUpMenu.popUpMenuActive += HandlePopUpMenuState;
    }

    private void HandlePopUpMenuState(bool isActive)
    {
        timerIsRunning = !isActive; 
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
        PopUpMenu.popUpMenuActive += HandlePopUpMenuState;
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
                PlayerPrefs.SetInt("VictoryScore", gold);
                SceneManager.LoadScene("Scenes/VictoryPage");
            }
     
            DisplayTime(timeRemaining);

            if (timeRemaining <= 60 && countNr == 0) // Anropa ChangeTimerColor() endast en gång när tiden når eller går under 60 sekunder
            {
                ChangeTimerColor();
                countNr += 1;
            }

            if (timeRemaining <= speedUpTime)
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

    private void DisableHeart()
    {

        if (lifesLeft == 1)
        {
            PlayerPrefs.SetInt("FinalScore", gold);
            SceneManager.LoadScene("Scenes/GameOver");
        }
        if(lifesLeft > 1)
        {
            Destroy(heartImages[lifesLeft-1].gameObject);
            lifesLeft -= 1;
        }
        
    }


    private void ChangeTimerColor()
    {
        timerText.color = Color.red; // Ändra textens färg till rött
    }

}
