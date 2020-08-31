using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public string scene;

    //takes a scene name and load the scene
    public void loadScene(string scene){

        Time.timeScale = 1;
        SceneManager.LoadScene(scene);

    }
}
