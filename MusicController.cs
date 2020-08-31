using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    //Declare variables
    public static bool isPlaying = false;
    public AudioSource m_MyAudioSource;
    public static MusicController instance;

    // Use this for initialization
    void Start()
    {
        //Instatiate a object of the script
        instance = this;
        //Get the audio source
        m_MyAudioSource = GetComponent<AudioSource>();

        //Check if the music is turned off from the settings
        if (PlayerPrefs.GetInt("isMusicOff") == 0)
        {
            //if the music is already playing, we don't need to play that again
            if (!isPlaying)
            {

                m_MyAudioSource.Play();
                isPlaying = true;
            }
        }
        else
        {
            stopMusic();
        }

        //The music gameobject should not be destroyed so that music can keep playing across all the scenes
        DontDestroyOnLoad(this.gameObject);
    }

    //Stops the music playing
    public void stopMusic()
    {

        m_MyAudioSource.Stop();
    }

    //Play music
    public void playMusic()
    {

        m_MyAudioSource.Play();
    }
}
