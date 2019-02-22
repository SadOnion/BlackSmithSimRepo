using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoText : MonoBehaviour {

	
	
	public Text text;
	// Update is called once per frame
	void Update () {
        transform.position = Input.mousePosition + Vector3.up*(Camera.main.scaledPixelHeight/8);
        
    }

    public void UpdateText(Item i)
    {
        text.text = i.name + "\n" + "Succes Rate:" + i.succesModifier + "%"+"\n"+"Gold Multiplier: "+i.goldMult;
    }
}
