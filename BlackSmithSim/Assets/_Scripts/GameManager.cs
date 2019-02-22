using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public SerializationManager serializationManager;
    public Player player;
    private static GameManager _instance;

    private bool isGameActive = true;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject o = new GameObject("GameManager");
                _instance = o.AddComponent<GameManager>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null) _instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        serializationManager = new SerializationManager();
        DontDestroyOnLoad(gameObject);


    }


    // Update is called once per frame
    void Update() {
        if (isGameActive) ChecForGameOver();
    }
    private void GameOver()
    {
        SceneManager.LoadScene("MainMenu");
        isGameActive = false;
    }
    private void ChecForGameOver()
    {
        if (player.gold < 0) GameOver();
        if (player.HasAnyMetalToCraft() && player.gold < 5 && player.inventory.items.Count == 0) GameOver();
    }
    public void NewGame()
    {
        player = new Player();
        isGameActive = true;
        SceneManager.LoadScene("Forge");

    }
    public void LoadGame()
    {
        if (serializationManager.isGameSaved())
        {
            SaveData data = serializationManager.Load();
            player = new Player();
            player.gold = data.gold;
            player.bronze=data.bronze;
            player.iron = data.iron;
            player.titanum=data.titanum;
            player.cobalt=data.cobalt ;
            player.mythril=data.mythril;
            player.inventory = new Inventory();
            foreach(ItemSer i in data.inv)
            {
                Item item = new Item();
                item.name = i.name;
                item.isSword = i.isSword;
                item.succesModifier = i.succesModifier;
                item.icon = Resources.Load<Sprite>(Path.GetFileNameWithoutExtension(i.icon));
                
                player.inventory.Add(item);
            }

            SceneManager.LoadScene("Forge");
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}
