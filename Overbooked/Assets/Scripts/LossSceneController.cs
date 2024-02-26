using UnityEngine;
using UnityEngine.UI;

public class LossSceneController : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        // Hämta poängen från PlayerPrefs
        int finalScore = PlayerPrefs.GetInt("FinalScore");

        // Visa poängen på skärmen
        scoreText.text = "Final Score: " + finalScore.ToString();
    }
}