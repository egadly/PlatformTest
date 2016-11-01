using UnityEngine;
using System.Collections;

public class TotKeys : MonoBehaviour {

    GameObject[] keys;
    public int numKeys;
	// Use this for initialization
	void Start ()
    {
        //Get total number of keys and store them in integer variable to compare with 
        //the number of keys the player has
        keys = GameObject.FindGameObjectsWithTag("Key");
        numKeys = keys.Length;
        Debug.Log(numKeys.ToString());
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
