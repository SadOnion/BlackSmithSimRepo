using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {
    public Text mainText;
    public Image mainImage;
    public Button left;
    
    public Button right;

    public Sprite[] slide;
    public string[] tutorialString;

    private int iterator = 0;
	// Use this for initialization
	void Start () {
        mainImage.sprite = slide[iterator];
        mainText.text = tutorialString[iterator];
    }
	
	// Update is called once per frame
	void Update () {
        if (iterator == 0) left.interactable = false;
        else left.interactable = true;

        if (iterator == slide.Length-1) right.interactable = false;
        else right.interactable = true;
	}
    public void Exit()
    {
        gameObject.SetActive(false);
    }
    public void NextSlide()
    {
        iterator++;
        mainImage.sprite = slide[iterator];
        mainText.text = tutorialString[iterator];
    }
    public void BackSlide()
    {
        iterator--;
        mainImage.sprite = slide[iterator];
        mainText.text = tutorialString[iterator];

    }
}
