using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryHandler : MonoBehaviour
{
    public Text scoreText;
    public List<Image> starImages;
    private int starCount;
    public Sprite yellowStarSprite;
    public Sprite grayStarSprite;

    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("VictoryScore");

        if (finalScore < 40)
        {
            starCount = 1;
        }
        else if (finalScore >= 40 && finalScore < 60)
        {
            starCount = 2;
        }
        else if (finalScore >= 60 && finalScore < 80)
        {
            starCount = 3;
        }
        else if (finalScore >= 80 && finalScore < 100)
        {
            starCount = 4;
        }
        else
        {
            starCount = 5;
        }

        foreach (var image in starImages)
        {
            image.sprite = grayStarSprite;
            image.gameObject.SetActive(true);
        }


        for (int i = 0; i < starCount; i++)
        {
            starImages[i].sprite = yellowStarSprite;
        }

        scoreText.text = "My score: " + finalScore.ToString() + "kr";
    }
}