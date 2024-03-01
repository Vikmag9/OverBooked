using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour
{
    public Button startButton;
    public Button boyCharacter;
    public Button girlCharacter;
    private bool girl = false;
    private bool boy = false;
    private Color boyButton;
    private Color girlButton;
 
    void Start()
    {
        startButton.gameObject.SetActive(false);
        boyButton = boyCharacter.image.color;
        girlButton = girlCharacter.image.color;
    }

    public void GirlClicked()
    {
        girl = !girl;
        HighlightCharacterButton(girlCharacter);

        if (girl)
        {
            OnCharacterButtonClicked();
        } else
        {
            startButton.gameObject.SetActive(false);
            girlCharacter.image.color = girlButton;
        }
    }


    public void BoyClicked()
    {
        boy = !boy;
        HighlightCharacterButton(boyCharacter);

        if (boy)
        {
            OnCharacterButtonClicked();
        }
        else
        {
            startButton.gameObject.SetActive(false);
            boyCharacter.image.color = boyButton;
        }
    }

    public void HighlightCharacterButton(Button button)
    {
        Color highlightColor = Color.yellow; // Du kan justera färgen efter dina preferenser
        button.image.color = highlightColor;
    }

    public void OnCharacterButtonClicked()
    {
        startButton.gameObject.SetActive(true);
    }
}
