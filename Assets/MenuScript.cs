using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Button startText; //Play Button
    public Button exitText;

	// Use this for initialization
	void Start () {
        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        quitMenu.enabled = false; //Hides quit menu in start up
    }
	
    public void ExitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
    }

    public void NoPress()
    { // No Button is pressed
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }

    public void StartLevel()
    { //Play button is pressed
        Application.LoadLevel(1);
    }

    public void ExitGame()
    { //Quit the game
        Application.Quit();
    }

	// Update is called once per frame
	void Update () {
	
	}
}
