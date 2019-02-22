using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SerializationManager  {

    private const string path  = "SaveFile.data";

    public void Save(Player player)
    {
        TaxSystem tax = Object.FindObjectOfType<TaxSystem>();
        SaveData data = new SaveData();
        data.gold = player.gold;
        data.bronze = player.bronze;
        data.iron = player.iron;
        data.titanum = player.titanum;
        data.cobalt= player.cobalt;
        data.mythril= player.mythril;
        foreach(Item i in player.inventory.items)
        {
            data.inv.Add(new ItemSer(i));
        }
        data.taxPaid = tax.taxPaid;
        data.timeToNextTax = tax.currentTime;

        using (FileStream file = new FileStream(path,FileMode.OpenOrCreate))
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, data);
        }
    }
    public SaveData Load()
    {
        SaveData loadData;
        using (FileStream file = new FileStream(path, FileMode.Open))
        {
            BinaryFormatter bf = new BinaryFormatter();
            loadData = (SaveData)bf.Deserialize(file);
        }
        return loadData;
    }
    public bool isGameSaved()
    {
        return File.Exists(path);
    }
	
}
[System.Serializable]
public class SaveData
{
    public int gold;
    public int bronze;
    public int iron;
    public int titanum;
    public int cobalt;
    public int mythril;
    public List<ItemSer> inv;
    public int taxPaid;
    public float timeToNextTax;

    public SaveData()
    {
        inv = new List<ItemSer>();
    }
}
[System.Serializable]
public class ItemSer
{
    public string name ;
    [SerializeField]
    public string icon;

    public bool isSword;
    public int succesModifier;

    public ItemSer(Item i)
    {
        name = i.name;
        icon = AssetDatabase.GetAssetPath(i.icon);
        isSword = i.isSword;
        succesModifier = i.succesModifier;
    }
}
