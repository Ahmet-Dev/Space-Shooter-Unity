using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void redirect(string url){

        Application.OpenURL(url);
    }

    public void musicSettings(){
        if (PlayerPrefs.GetInt("isMusicOff") == 0)
        {
            AudioListener.pause = true;
            PlayerPrefs.SetInt("isMusicOff", 1);
        }
        else
        {
            AudioListener.pause = false;
            MusicController.instance.playMusic();
            PlayerPrefs.SetInt("isMusicOff", 0);

        }
    }
}
