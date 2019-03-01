using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour {


    public Slider slider;

	
	
	// Update is called once per frame
	void Update () {
       
	}

    public void ChangeVolume()
    {
        foreach(var s in AudioManager.instance.sounds)
        {
            s.source.volume = slider.value;
        }
    }
    public void NewLevel()
    {
        GameManager.Instance.NewGame();
    }
    public void LoadGame()
    {
        GameManager.Instance.LoadGame();
    }
    public void Exiut()
    {
        Application.Quit();
    }
}
