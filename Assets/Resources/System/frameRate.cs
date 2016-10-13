using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class frameRate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetKeyDown(KeyCode.Escape) ) Application.Quit();
		if (Input.GetKeyDown (KeyCode.Alpha1))
			SceneManager.LoadScene ("scene");
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			SceneManager.LoadScene ("scene2");
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			SceneManager.LoadScene ("scene3");
		}
	}
}
