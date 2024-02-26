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
    public float initialDelay = 2f;
    public float fillDelay = 1f;
    public AudioClip fillSound; // Ljudklipp f?r att spela n?r stj?rnorna fylls
    private AudioSource audioSource;

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
            image.fillAmount = 0f;
            //image.gameObject.SetActive(true);
        }

        audioSource = gameObject.AddComponent<AudioSource>(); // L?gger till AudioSource-komponenten
        audioSource.clip = fillSound;

        StartCoroutine(FillStars());
        scoreText.text = "My score: " + finalScore.ToString() + "kr";

    }

    IEnumerator FillStars()
        {
        yield return new WaitForSeconds(initialDelay);
        for (int i = 0; i < starCount; i++)
            {
                starImages[i].sprite = yellowStarSprite;
                if (fillSound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(fillSound); // Spela ljudet n?r stj?rnan fylls
                }
                float elapsedTime = 0f;
                while (elapsedTime < fillDelay)
                {
                    elapsedTime += Time.deltaTime;
                    starImages[i].fillAmount = elapsedTime / fillDelay; // Uppdatera fyllningsgraden ?ver tiden
                    yield return null;
                }
                starImages[i].fillAmount = 1f;
        }
     }

}