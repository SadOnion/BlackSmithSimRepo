using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class QuestHandler : MonoBehaviour {

    public Quest quest;
    public QuestUI questUI;
    private Player player;
    private int currentReward;
    // Use this for initialization
    private void Awake()
    {
        GenerateNewQuest();
    }
    void Start () {
        player = GameManager.Instance.player;
        
	}
	
	

    public int CalculateSuccesRate(ItemSlot swordSlot,ItemSlot shieldSlot)
    {
        int rate = quest.baseSuccesRate;
        
        if(swordSlot.item != null)
        {
            rate += swordSlot.item.succesModifier;
        }
        if(shieldSlot.item != null)
        {
            rate += (int)Mathf.Ceil(shieldSlot.item.succesModifier / 2);
        }
        if (swordSlot.item != null && shieldSlot.item != null)
        {
            rate *= 2;
            
        }
        if (rate > 100) rate = 100;
        return rate;
    }
    public int CalculateReward(ItemSlot swordSlot,ItemSlot shieldSlot)
    {
        float rate = quest.reward;
        
        if (swordSlot.item != null)
        {
            rate *= swordSlot.item.goldMult;
        }
        if (shieldSlot.item != null)
        {
            rate *= shieldSlot.item.goldMult;
        }
        
        currentReward = (int)Mathf.Ceil(rate);
        return currentReward;
    }
    public bool DidQuestSucced(Quest q)
    {
        int value = Random.Range(0, 101);
        return value <= questUI.succesRate;
        
        
    }
    private void RemoveItems()
    {
        Item[] items = questUI.GetItems();
        player.inventory.Remove(items[0]);
        player.inventory.Remove(items[1]);
    }
    public void AcceptQuest()
    {
        if (DidQuestSucced(quest))
        {
            player.Add(Metal.Gold, int.Parse(questUI.reward.text));
        }
        GenerateNewQuest();
        RemoveItems();
        questUI.UpdateUI();
    }
    public void DeclineQuest()
    {
        player.Take(Metal.Gold, 10);
        GenerateNewQuest();
        RemoveItems();
        questUI.UpdateUI();
    }
    public void GenerateNewQuest()
    {
        int succesRate = Random.Range(1, 40);
        quest = new Quest(succesRate,(int)Mathf.Ceil((1600-(int)Mathf.Pow(succesRate,2))/10));

    }
}
