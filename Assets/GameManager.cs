using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public UIManager UI;
	public bool isPaused;
    
	// Use this for initialization
	void Start () {
        UI.GetComponentInChildren<Canvas>().enabled = false;
		isPaused = false;
		Time.timeScale = 1.0f;
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void togglePauseMenu()
    {
        if (!UI.GetComponentInChildren<Canvas>().enabled)
        {
            UI.GetComponentInChildren<Canvas>().enabled = true;
			isPaused = true;
            Time.timeScale = 0f;
        }
        else
        {
            UI.GetComponentInChildren<Canvas>().enabled = false;
			isPaused = false;
            Time.timeScale = 1.0f;
        }
    }
		

    public void loadMainMenu()
    {
        SceneManager.LoadScene("test_menu");
    }
}
