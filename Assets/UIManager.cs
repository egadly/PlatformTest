using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameManager GM;
    public MusicManager MM;

    private Slider music_Slider;

	// Use this for initialization
	void Start () {
        music_Slider = GameObject.Find("Music_Slider").GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        pausePress();	
	}

    public void pausePress()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            GM.togglePauseMenu();
        }
    }

    public void musicSliderValue(float val)
    {
        MM.setVolume(val);
    }

    public void musicToggle(bool val)
    {
        music_Slider.interactable = val;
        MM.setVolume(val ? music_Slider.value : 0f);
    }
}
