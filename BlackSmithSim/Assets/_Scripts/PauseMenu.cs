
using UnityEngine;


public class PauseMenu : MonoBehaviour {

	

    public void Resume()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    public void SaveAndExit()
    {
        GameManager.Instance.serializationManager.Save(GameManager.Instance.player);
        Application.Quit();
    }
    public void Exit()
    {
        Application.Quit();
    }
}
