using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController {

    public static Sprite gamePlayingRocket;


    public static void setHighScore(int score){

        PlayerPrefs.SetInt("highScore", score);
    }

    public static int getHighScore(){

        return PlayerPrefs.GetInt("highScore");
    }

    public static void setCoins(int coins){

        PlayerPrefs.SetInt("coins", coins);
    }

    public static int getCoins(){
        return PlayerPrefs.GetInt("coins");
    }

}
