using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour
{
    public Button startButton;
    public Button boyCharacter;
    public Button girlCharacter;
    private Color boyColor;
    private Color girlColor;
    private Color highlightedColor = new Color(1f, 0.5f, 0f, 0.6f); 

    void Start()
    {
        startButton.gameObject.SetActive(false);
        boyColor = boyCharacter.GetComponent<Image>().color;
        girlColor = girlCharacter.GetComponent<Image>().color;
    }

    public void GirlClicked()
    {
        CharacterSelection.selectedCharacter = 1;
        UpdateCharacterButtons();
    }

    public void BoyClicked()
    {
        CharacterSelection.selectedCharacter = 0;
        UpdateCharacterButtons();
    }

    void UpdateCharacterButtons()
    {
        if (CharacterSelection.selectedCharacter == 1)
        {
            boyCharacter.GetComponent<Image>().color = boyColor; 
            girlCharacter.GetComponent<Image>().color = highlightedColor; 
        }
        else
        {
            girlCharacter.GetComponent<Image>().color = girlColor;
            boyCharacter.GetComponent<Image>().color = highlightedColor; 
        }
        startButton.gameObject.SetActive(true);
    }
}