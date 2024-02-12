using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quest : MonoBehaviour
{
    public List<Goal> Goals { get; set; } = new List<Goal>();
    public string QuestName { get; set; }
    public string Description { get; set; }
    public int ExperienceReward { get; set; }
    public int ItemReward { get; set; } //Item
    public bool Completed { get; set; }


    public void CheckGoal()
    {
        Completed = Goals.All(g => g.Completed);
        if (Completed) GiveReword();
    }

    public void GiveReword()
        {
        if (ItemReward != null)
        {
            InventoryController.Instance.GiveItem(ItemReward);
        }
        }

}