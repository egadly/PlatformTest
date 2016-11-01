using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    private bool complete = false;
    GameObject player;
    private int score;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        scoreText.text = "5000";
    }

    // Update is called once per frame
    void Update()
    {

        string scoreGet;
        scoreGet = scoreText.text.ToString();
        bool result = int.TryParse(scoreGet, out score);
        if (score > 0)
        {
             complete = player.GetComponent<main>().levelComplete;
            if(!complete)
                score--;
        }

        else
        {
            score = 0;

            //Show level failed screen, retry or exit.
        }
        scoreText.text = score.ToString();
    }
}
