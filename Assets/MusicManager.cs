﻿using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
    UIManager UI;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setVolume(float val)
    {
        GetComponent<AudioSource>().volume = val;
    }
}
