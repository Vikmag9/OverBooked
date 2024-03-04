using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private int currentLevel = 0;
    private List<QuestObjects> activeQuests;
    private int life = 3;
    private bool gameOver = false;

    public GameObject girlCharacter;
    public GameObject boyCharacter;

    public List<GameObject> characterModels;


    public int getPlayerCurrentLevel()
    {
        return this.currentLevel;
    }

    public void setPlayerCurrentLevel(int newLevel)
    {
        this.currentLevel = newLevel;
    }

    private void Start()
    {
        //Physics.IgnoreLayerCollision(7, 8);
        GameObject[] goArray = FindGameObjectsWithLayer(7);

        int characterNum = CharacterSelection.selectedCharacter;

        //characterModels[characterNum].SetActive(true);
        //characterModels[1 - characterNum].SetActive(false);

        if (characterNum == 1)
        {
            // Visa tjejkarakteren och dölj killkarakteren
            girlCharacter.SetActive(true);
            boyCharacter.SetActive(false);
        }
        else
        {
            // Visa killkarakteren och dölj tjejkarakteren
            girlCharacter.SetActive(false);
            boyCharacter.SetActive(true);
        }


        for (int i = 0;  i < goArray.Length; i++)
        {
            Physics.IgnoreCollision(goArray[i].GetComponent<Collider>(), GetComponent<Collider>());
        }
        
        EventManager.current.playerLoseLife += LoseLife;

            
        
        
    }
    private void Update()
    {
        if(this.transform.position.z <= -2)
        {
            this.transform.position = new Vector3(transform.position.x, transform.position.y, -1.7f);
        }
        
    }

    public void LoseLife()
    {
        
        life -= 1;
        if(life <= 0 )
        {
            gameOver = true;
        }
        
    }

    GameObject[] FindGameObjectsWithLayer(int layer)
    {
        GameObject[] goArray = GameObject.FindObjectsOfType<GameObject>();
        System.Collections.Generic.List<GameObject> goList = new System.Collections.Generic.List<GameObject>();

        for (int i = 0; i < goArray.Length; i++)
        {
            if (goArray[i].layer == layer)
            {
                goList.Add(goArray[i]);
            }
        }

        if (goList.Count == 0)
        {
            return null;
        }

        return goList.ToArray();
    }
}



