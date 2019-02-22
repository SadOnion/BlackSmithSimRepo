using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject infoPanel;
    public Image icon;
    [HideInInspector]
    public Item item;
    public event EventHandler ItemChange;
    private ItemSlot shieldSlot;
    private ItemSlot swordSlot;

    private void Start()
    {
        shieldSlot = GameObject.FindGameObjectWithTag("ShieldSlot").GetComponent<ItemSlot>();
        swordSlot = GameObject.FindGameObjectWithTag("SwordSlot").GetComponent<ItemSlot>();
        
    }
    
    
    public void AddItem(Item i)
    {
        icon.enabled = true;
        item = i;

        
        icon.sprite = i.icon;
        OnItemChange();
    }
    protected virtual void OnItemChange()
    {
        if (ItemChange != null)
            ItemChange(this,EventArgs.Empty);
    }
    public void GoToQuestSlot()
    {
        
        if (item.isSword)
        {
            if(swordSlot.item != null)
            {
                swordSlot.AddItem(Replace(swordSlot.item));
            }
            else{
                swordSlot.AddItem(item);
                ClearSlot();
            }
            
        }
        else{
            if(shieldSlot.item != null)
            {
                shieldSlot.AddItem(Replace(shieldSlot.item));
            }
            else{
                shieldSlot.AddItem(item);
                ClearSlot();
            }
        }
    }
    
    public Item Replace(Item i)
    {
        Item returnItem = item;
        AddItem(i);
        OnItemChange();
        return returnItem;
        
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        OnItemChange();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
        if(item != null )
        {
            infoPanel.GetComponent<InfoText>().UpdateText(item);
            infoPanel.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
        infoPanel.SetActive(false);
    }
}
