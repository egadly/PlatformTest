using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour {

    public Canvas options;
    public Button volumeUp;
    public Button volumeDown;
    public Button controls;
    public Button exit;
	// Use this for initialization
	void Start () {
        options = options.GetComponent<Canvas>();
        options.enabled = false;
        volumeUp = volumeUp.GetComponent<Button>();
        volumeDown = volumeDown.GetComponent<Button>();
        controls = controls.GetComponent<Button>();
        exit = exit.GetComponent<Button>();
    }
	
    public void volumeUpPress()
    {

    }

    public void volumeDownPress()
    {

    }

    public void controlPress()
    {

    }

    public void exitPress()
    {

    }

	// Update is called once per frame
	void Update () {
	
	}
}
