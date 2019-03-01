using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public ScoreSerializer scoreSerializer;
    public SerializationManager serializationManager;
    public Player player;
    private static GameManager _instance;
    public int taxPaid;
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
        scoreSerializer = new ScoreSerializer();
        DontDestroyOnLoad(gameObject);
        

    }


    // Update is called once per frame
    void Update() {
        if (isGameActive) ChecForGameOver();
    }
    private void GameOver()
    {
        taxPaid = FindObjectOfType<TaxSystem>().taxPaid;
        SceneManager.LoadScene("GameOver");
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
        taxPaid = 0;
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        isGameActive = true;

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
                item.icon = Resources.Load<Sprite>(i.name);
                
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
