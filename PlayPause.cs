using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPause : MonoBehaviour {

    public GameObject play;
    public GameObject pause;

    public void PauseGame()
    {
        Time.timeScale = 0;
        play.SetActive(true);
        pause.SetActive(false);
        //Disable scripts that still work while timescale is set to 0
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;

        pause.SetActive(true);

        play.SetActive(false);
        //pausePanel.SetActive(false);
        //enable the scripts again
    }
}
