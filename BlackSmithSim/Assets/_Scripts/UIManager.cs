using UnityEngine.UI;
using UnityEngine;
using System;
[Serializable]
public class UIManager : MonoBehaviour {

    public static UIManager Instance;
	public Text[] goldText;
	public Toggle bronzeToggle;
	public Toggle ironToggle;
	public Toggle titanumToggle;
	public Toggle cobaltToggle;
    public Toggle mythrilToggle;
    public CraftingManager craftingManager;
    public PauseMenu pauseMenu;

    public Button[] buttonsDirection;
    
	private Player player;

    private const int bronzeValue = 5;
    private const int ironValue = 15;
    private const int titanumValue = 30;
    private const int cobaltValue = 55;
    private const int mythrilValue = 80;





    private void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
    void Start () {
		
		player = GameManager.Instance.player;
        player.ValueChange += OnValueChanged;
        OnValueChanged(this, EventArgs.Empty);
        GetComponent<Canvas>().overrideSorting = true;

	}

    
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseMenu.gameObject.SetActive(true);
        }
	}

	private void OnValueChanged(object sender,EventArgs e)
	{

      
        foreach(Text t in goldText)
        {
            t.text = "Gold:" + player.gold;
        }
		bronzeToggle.GetComponentInChildren<Text>().text = "Bronze:" + player.bronze;
		ironToggle.GetComponentInChildren<Text>().text = "Iron:" + player.iron;
		titanumToggle.GetComponentInChildren<Text>().text = "Titanum:" + player.titanum;
		cobaltToggle.GetComponentInChildren<Text>().text = "Cobalt:" + player.cobalt;
		mythrilToggle.GetComponentInChildren<Text>().text = "Mythril:" + player.mythril;
    }

   
    public Metal WhichMetalIsActive()
    {
        if (bronzeToggle.isOn) return Metal.Bronze;
        if (ironToggle.isOn) return Metal.Iron;
        if (titanumToggle.isOn) return Metal.Titanum;
        if (cobaltToggle.isOn) return Metal.Cobalt;
        if (mythrilToggle.isOn) return Metal.Mythril;
        return Metal.Bronze;
    }
    public void BuyMetal(int metalIndex)
    {
        
        Metal m = (Metal)metalIndex;
        switch (m)
        {
            case Metal.Bronze:
                if(player.gold >= bronzeValue)
                {
                    player.Take(Metal.Gold, bronzeValue);
                    player.Add(Metal.Bronze, 1);
                    AudioManager.instance.Play("Buy");
                }
                break;
            case Metal.Iron:
                if (player.gold >= ironValue)
                {
                    player.Take(Metal.Gold, ironValue);
                    player.Add(Metal.Iron, 1);
                    AudioManager.instance.Play("Buy");
                }
                break;
            case Metal.Titanum:
                if (player.gold >= titanumValue)
                {
                    player.Take(Metal.Gold, titanumValue);
                    player.Add(Metal.Titanum, 1);
                    AudioManager.instance.Play("Buy");
                }
                break;
            case Metal.Cobalt:
                if (player.gold >= cobaltValue)
                {
                    player.Take(Metal.Gold, cobaltValue);
                    player.Add(Metal.Cobalt, 1);
                    AudioManager.instance.Play("Buy");
                }
                break;
            case Metal.Mythril:
                if (player.gold >= mythrilValue)
                {
                    player.Take(Metal.Gold, mythrilValue);
                    player.Add(Metal.Mythril, 1);
                    AudioManager.instance.Play("Buy");
                }
                break;
        }

    }

    public void UIStatusChange()
    {
        
        craftingManager.ResetCraftPanel();
    }
    
}
