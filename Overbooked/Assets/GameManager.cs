using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private int gold = 0;
    // Start is called before the first frame update
    void Start()
    {
        Singelton();
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
        
    }

    public void setGold(int amount) { gold += amount; }
}
