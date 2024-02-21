using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class animation_manager_guest_1 : MonoBehaviour
{
    private Animator ani;

    public int guestID;
    // Start is called before the first frame update
    void Start()
    {
        ani = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        EventManager.current.questActive += quest_active_wave;
        EventManager.current.questDeactive += quest_deactive_emote;
    }

    public void quest_active_wave()
    {
        if(guestID = this.id){
        ani.SetBool("activate_quest", true);
        }
    }

    public void quest_deactive_emote()
    {
        ani.SetBool("activate_quest", false);
    }

    public void setCurrentRoomID(int id)
    {
        guestID = id;
    }
}
