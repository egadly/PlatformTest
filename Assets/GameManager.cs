using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public UIManager UI;
    
	// Use this for initialization
	void Start () {
        UI.GetComponentInChildren<Canvas>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void togglePauseMenu()
    {
        if (!UI.GetComponentInChildren<Canvas>().enabled)
        {
            UI.GetComponentInChildren<Canvas>().enabled = true;
            Time.timeScale = 1.0f;
        }
        else
        {
            UI.GetComponentInChildren<Canvas>().enabled = false;
            Time.timeScale = 0f;
        }
    }
}
