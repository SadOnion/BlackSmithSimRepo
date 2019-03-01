using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour {
    public InputField inputField;
    public GameObject newScore;
    
    private int taxPaid;
    private void Start()
    {
        taxPaid = GameManager.Instance.taxPaid;
        newScore.SetActive(GameManager.Instance.scoreSerializer.CanWriteNewScore(taxPaid));
    }

    

    public void SaveNewScore()
    {
        Score scoreToSave = new Score(taxPaid, inputField.text);
        List<Score> list = GameManager.Instance.scoreSerializer.ReadScoreList();
        list.Add(scoreToSave);
        list.Sort();
        
        list.Remove(list[list.Count - 1]);
        GameManager.Instance.scoreSerializer.SerializeList(list);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }



}
