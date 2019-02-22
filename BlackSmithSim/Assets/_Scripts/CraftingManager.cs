using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CraftingManager : MonoBehaviour {

    public Slider progresBar;
    public Toggle swordToggle;
    public Toggle shieldToggle;
    public Button craftButton;
    public Metal activeMetal;
    public Sprite sword;
    public Item[] items;
    public Transform spawnPosition;
    private const int swordCraftAmount = 3;
    private const int shieldCraftAmount = 5;
    private int howManySmashes = 0;
    private Player player;

    // Use this for initialization
    void Start () {
        player = GameManager.Instance.player;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        activeMetal = UIManager.Instance.WhichMetalIsActive();
        craftButton.interactable = CanMakeItem();
    }


    public void Smash()
    {
        howManySmashes++;
        
        if (shieldToggle.isOn)
        {
            progresBar.value = (float)howManySmashes / shieldCraftAmount;
            if(howManySmashes >= shieldCraftAmount)
            {
                player.Take(activeMetal, shieldCraftAmount);
                CraftShield();
                Invoke("ResetCraftPanel", 0.35f);
            }
            
        }
        if(swordToggle.isOn)
        {
            progresBar.value = (float)howManySmashes / swordCraftAmount;
            if (howManySmashes >= swordCraftAmount)
            {
                player.Take(activeMetal, swordCraftAmount);
                CraftSword();
                Invoke("ResetCraftPanel", 0.35f);
            }
            
        }
        

    }
    
    public void CraftSword()
    {
        Item item;
        GameObject o = new GameObject("clone");
        o.AddComponent<SpriteRenderer>();
        switch (activeMetal)
        {
            case Metal.Bronze:
                item = Array.Find(items, x => x.name == "Bronze Sword");
                
                break;
            case Metal.Iron:
                item = Array.Find(items, x => x.name == "Iron Sword");
                
                break;
            case Metal.Titanum:
                item = Array.Find(items, x => x.name == "Titanum Sword");
                break;
            case Metal.Cobalt:
                item = Array.Find(items, x => x.name == "Cobalt Sword");
                break;
            case Metal.Mythril:
                item = Array.Find(items, x => x.name == "Mythril Sword");
                break;
            default:
                item = Array.Find(items, x => x.name == "Bronze Sword");
                break;
        }
        o.GetComponent<SpriteRenderer>().sprite = item.icon;
        Rigidbody2D body = o.AddComponent<Rigidbody2D>();
        o.transform.position = spawnPosition.position;
        body.velocity = new Vector2(3, 5);
        body.AddTorque(100);
        Destroy(o, 2);
        player.inventory.Add(item);
    }
    public void CraftShield()
    {
        Item item;
        GameObject o = new GameObject("clone");
        o.AddComponent<SpriteRenderer>();
        switch (activeMetal)
        {
            case Metal.Bronze:
                item = Array.Find(items, x => x.name == "Bronze Shield");
                break;
            case Metal.Iron:
                item = Array.Find(items, x => x.name == "Iron Shield");
                break;
            case Metal.Titanum:
                item = Array.Find(items, x => x.name == "Titanum Shield");
                break;
            case Metal.Cobalt:
                item = Array.Find(items, x => x.name == "Cobalt Shield");
                break;
            case Metal.Mythril:
                item = Array.Find(items, x => x.name == "Mythril Shield");
                break;
            default:
                item = Array.Find(items, x => x.name == "Bronze Shield");
                break;
        }


        o.GetComponent<SpriteRenderer>().sprite = item.icon;
        Rigidbody2D body = o.AddComponent<Rigidbody2D>();
        o.transform.position = spawnPosition.position;
        body.velocity = new Vector2(3, 5);
        body.AddTorque(100);
        Destroy(o, 2);

        player.inventory.Add(item);

    }
    public void ResetCraftPanel()
    {
        progresBar.value = 0;
        howManySmashes = 0;
    }
    public bool CanMakeItem()
    {
        if (shieldToggle.isOn)
        {
            return player.HasEnoughMetal(activeMetal, shieldCraftAmount);
        }
        if (swordToggle.isOn)
        {
            return player.HasEnoughMetal(activeMetal, swordCraftAmount);
        }
        return false;
    }
}
