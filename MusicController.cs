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
        m_MyAudioSource = GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("isMusicOff") == 0)
        {
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
        DontDestroyOnLoad(this.gameObject);
    }
    public void stopMusic()
    {

        m_MyAudioSource.Stop();
    }
    public void playMusic()
    {

        m_MyAudioSource.Play();
    }
}
