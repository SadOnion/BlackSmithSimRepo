using UnityEngine.UI;
using UnityEngine;

public class ContinueButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Button>().interactable = GameManager.Instance.serializationManager.isGameSaved();	
	}
	
	
}
