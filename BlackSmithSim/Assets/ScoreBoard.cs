using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    public int ofset=50;
	public GameObject raw;
	public int maxRaws;
	private ScoreSerializer scoreSerializer;
	private List<Score> scoreList;

	// Use this for initialization
	void Awake () {
		scoreSerializer = new ScoreSerializer();
		scoreList = new List<Score>();
        scoreList = GameManager.Instance.scoreSerializer.ReadScoreList();
       
		
		
	}
	public void DisableScoreBoard()
    {
        gameObject.SetActive(false);
    }
	 public void GenerateScoreBorad()
	{
		gameObject.SetActive(true);
		try
		{
			for (int i = 0; i < maxRaws; i++)
			{
				GameObject o = Instantiate(raw, raw.transform.position + Vector3.down * ofset*(i+1), Quaternion.identity);
                o.transform.SetParent(gameObject.transform);
				Text[] teksts = o.GetComponentsInChildren<Text>();
				teksts[0].text = (i+1).ToString();
                
                if (scoreList.Count <= i)
				{
					teksts[1].text = "none";
					teksts[2].text = "none";
				}
				else
				{
					teksts[1].text = scoreList[i].name;
					teksts[2].text = scoreList[i].taxPaid.ToString();
				}

			}
		}
		catch(SerializationException e)
		{
			for (int i = 1; i < maxRaws + 1; i++)
			{
				GameObject o = Instantiate(raw, raw.transform.position+Vector3.down*ofset, Quaternion.identity);
				Text[] teksts = o.GetComponentsInChildren<Text>();
				teksts[0].text = i.ToString();
				teksts[1].text = "none";
				teksts[2].text = "none";
				
			   

			}
		}
		
	}
	
}
