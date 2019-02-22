using System;
using UnityEngine.UI;
using UnityEngine;

public class QuestUI : MonoBehaviour {

    public Button accept;
    public Button decline;
    public Text info;
    public Text reward;
    public QuestHandler questHandler;
    private ItemSlot[] slots;
    [Range(0,100)]
    public int succesRate;
    private Player player;


    private void Start()
    {
        player= GameManager.Instance.player;
        slots = GetComponentsInChildren<ItemSlot>();
        foreach (var item in slots)
        {
            item.ItemChange += OnItemChanged;
        }
        UpdateUI();
    }
    private void Update()
    {
        
    }

    public void OnItemChanged(object sender,EventArgs e)
    {
        succesRate = questHandler.CalculateSuccesRate(slots[0], slots[1]);
        UpdateUI();
    }

    public void UpdateUI()
    {
        info.text = "Chanse of Succes: " + succesRate + "%";
        reward.text = questHandler.CalculateReward(slots[0],slots[1]).ToString();
        accept.interactable = AcceptButtonInteractable();
        decline.interactable = DeclineButtonInteractable();
    }
    public Item[] GetItems()
    {
        Item[] temp = new Item[2];
        temp[0] = slots[0].item;
        temp[1] = slots[1].item;
        slots[0].ClearSlot();
        slots[1].ClearSlot();
        return temp;
    }
    private bool AcceptButtonInteractable()
    {
        if (slots[0].item != null || slots[1].item != null)
        {
           return true;
        }
        else
        {
           return false;
        }
    }
    private bool DeclineButtonInteractable()
    {
        if (player.gold < 10)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}
