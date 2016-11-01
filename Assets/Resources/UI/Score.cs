using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
	public GameManager gm;
    void Start()
    {

        scoreText.text = "5000";

    }

    // Update is called once per frame
    void Update()
    {
		
			int score = 0;
			string scoreGet;
			scoreGet = scoreText.text.ToString ();
			bool result = int.TryParse (scoreGet, out score);
			if (score > 0) {
				score--;
			
			} else {
				score = 0;

				//Show level failed screen, retry or exit.
			}
			scoreText.text = score.ToString ();

    }
}
