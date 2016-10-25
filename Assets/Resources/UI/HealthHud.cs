using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthHud : MonoBehaviour {

    public Sprite[] HeartSprites;
    public Image HeartUI;

    //Will be used to modify display based on player health.
     private main player;

    // Use this for initialization
    void Start()
    {
        //Will set object to the player.
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<main>();
    }

    // Update is called once per frame
    void Update()
    {
        //Test
        //HeartUI.sprite = HeartSprites[0];
        //HeartUI.sprite = HeartSprites[1];
        //HeartUI.sprite = HeartSprites[2];
        //HeartUI.sprite = HeartSprites[3];

        //Will be used to change the ui based on player health.
        HeartUI.sprite = HeartSprites[player.health];

    }
}
