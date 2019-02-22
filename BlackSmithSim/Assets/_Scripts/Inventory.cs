using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Inventory {

    public event EventHandler ItemChange;
    public List<Item> items;


    public Inventory()
    {
        items = new List<Item>();
    }

	

    public void Add(Item i)
    {
        items.Add(i);
        ItemChanged();
    }
    public void Remove(Item i)
    {
        items.Remove(i);
        ItemChanged();
    }

    protected virtual void ItemChanged()
    {
        if (ItemChange != null)
            ItemChange(this, EventArgs.Empty);
    }
}
