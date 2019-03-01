using System;
using UnityEngine.UI;
using UnityEngine;

public class TaxSystem : MonoBehaviour {

    private const int timeToNextTax = 75;
    private readonly int taxAmount = 100;
    public int currentTax;
    public float currentTime;
    public Text timer;
    public int taxPaid;
    public Text tax;
    private float seconds;
    private float minutes;
	// Use this for initialization
	void Start () {
        if (GameManager.Instance.serializationManager.isGameSaved())
        {
            SaveData data = GameManager.Instance.serializationManager.Load();
            currentTime = data.timeToNextTax;
            taxPaid = data.taxPaid;
            currentTax = taxAmount;
        }
        else
        {
            currentTime = timeToNextTax;
            currentTax = taxAmount;
            taxPaid = 0;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        UpdateUI();
        if (currentTime <= 0)
        {
            
            GameManager.Instance.player.Take(Metal.Gold, currentTax);
            taxPaid++;
            currentTime = timeToNextTax - 5 * taxPaid;
            if (currentTime < 30) currentTime = 30;
            RaiseTax();
        }
	}
    void UpdateUI()
    {
        currentTime -= Time.deltaTime;
        minutes = Mathf.Floor(currentTime / 60);
        seconds = Mathf.RoundToInt(currentTime % 60);
        timer.text = "Next Tax: " + minutes + ":" + seconds;
        tax.text = currentTax.ToString();
    }
    void RaiseTax()
    {
        currentTax = taxAmount + taxPaid * 50;
        if (taxPaid > 6) currentTax *= 2;
    }
}
