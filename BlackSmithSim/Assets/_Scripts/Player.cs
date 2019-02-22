using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Player {

    public int gold;
    public int bronze;
    public int iron;
    public int titanum;
    public int cobalt;
    public int mythril;
    public event EventHandler ValueChange;
    public Inventory inventory;


    public Player()
    {
        gold = 100;
        bronze = 9;
        iron = 0;
        titanum = 0;
        cobalt = 0;
        mythril = 0;
        inventory = new Inventory();
    }


    public void Add(Metal metal,int amount)
    {
        switch (metal)
        {
            case Metal.Gold:
                gold += amount;
                break;
            case Metal.Bronze:
                bronze += amount;
                break;
            case Metal.Iron:
                iron += amount;
                break;
            case Metal.Titanum:
                titanum+= amount;
                break;
            case Metal.Cobalt:
                cobalt+= amount;
                break;
            case Metal.Mythril:
                mythril+= amount;
                break;
        }
        ValueChanged();
    }
    public void Take(Metal metal,int amount)
    {
        switch (metal)
        {
            case Metal.Gold:
                    gold -= amount;
                break;
            case Metal.Bronze:
                
                    bronze -= amount;
                break;
            case Metal.Iron:
               
                    iron-= amount;
                break;
            case Metal.Titanum:
                
                    titanum -= amount;
                break;
            case Metal.Cobalt:
                
                    cobalt-= amount;
                break;
            case Metal.Mythril:
                
                    mythril-= amount;
                break;
        }
        ValueChanged();
    }

    

    
    protected virtual void ValueChanged()
    {
        
        if (ValueChange != null)
            ValueChange(this, EventArgs.Empty);
            
    }
    public bool HasAnyMetalToCraft()
    {
        return bronze <= 2 && iron <= 2 && titanum <= 2 && cobalt <= 2 && mythril <= 2;
    }
    public bool HasEnoughMetal(Metal m,int amount)
    {
        switch (m)
        {
            case Metal.Gold:
                if (gold < amount) return false;
                break;
            case Metal.Bronze:
                if (bronze < amount) return false;
                break;
            case Metal.Iron:
                if (iron < amount) return false;
                break;
            case Metal.Titanum:
                if (titanum < amount) return false;
                break;
            case Metal.Cobalt:
                if (cobalt < amount) return false;
                break;
            case Metal.Mythril:
                if (mythril< amount) return false;
                break;
        }
        return true;
    }

}
public enum Metal
{
    Gold,
    Bronze,
    Iron,
    Titanum,
    Cobalt,
    Mythril
}
