using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guestEmotes : MonoBehaviour
{
    public Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void quest_active_emote()
    {
        ani.SetFloat("quest_active", 1f);
    }
}
