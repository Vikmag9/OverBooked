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

    public List<GameObject> characterModels;

    private CharacterScript characterScript; 

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

        public int characterNum = characterScript.getCharacterNum();

        if(characterNum == 0){
            characterModels[characterNum].SetActive(true);
            characterModels[characterNum + 1].SetActive(false);
        }else{
            characterModels[characterNum].SetActive(true);
            characterModels[characterNum - 1].SetActive(false);
        }

        for(int i = 0;  i < goArray.Length; i++)
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



