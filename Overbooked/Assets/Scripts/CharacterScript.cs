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

    private int selectedCharacter = 0;
 
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
        selectedCharacter = 1;

        if (girl)
        {
            if (boy)
            {
                boyCharacter.image.color = boyButton;
                boyButton.a = 1f;
            }
            OnCharacterButtonClicked();
        } else
        {
            startButton.gameObject.SetActive(false);
            girlCharacter.image.color = girlButton;
            girlButton.a = 1f;
        }
    }


    public void BoyClicked()
    {
        boy = !boy;
        HighlightCharacterButton(boyCharacter);
        selectedCharacter = 0;
        if (boy)
        {
            if (girl)
            {
                girlCharacter.image.color = girlButton;
                girlButton.a = 1f;
            }

            OnCharacterButtonClicked();
        }
        else
        {
            startButton.gameObject.SetActive(false);
            boyCharacter.image.color = boyButton;
            boyButton.a = 1f;
        }
    }

    public void HighlightCharacterButton(Button button)
    {
        Color highlightColor = Color.yellow; // Du kan justera färgen efter dina preferenser
        highlightColor.a = 0.5f;
        button.image.color = highlightColor;
    }

    public void OnCharacterButtonClicked()
    {
        startButton.gameObject.SetActive(true);
    }

    public int getCharacterNum(){return selectedCharacter;}
}
