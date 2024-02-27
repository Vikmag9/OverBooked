using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class animation_manager_guest_1 : MonoBehaviour
{
    private Animator ani;

    public int guestID;

    public int roomID;

    public QuestGiver questGiver;
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
        if(guestID == questGiver.getRoomID()){
        roomID = questGiver.getRoomID();
        ani.SetBool("quest_active", true);
        }
    }

    public void quest_deactive_emote()
    {
        ani.SetBool("quest_active", false);
    }
}
