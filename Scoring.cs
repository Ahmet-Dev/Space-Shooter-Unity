using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

    public static int score = 0;
    public Text scoreText;
    public Text coinText;
	// Use this for initialization
	void Start () {

        //set the initial score
        score = 0;
        //set the coins, previously stored 
        coinText.text = GameController.getCoins().ToString();
	}
	
	// Update is called once per frame
	void Update () {

        //keeps updating scores
        scoreText.text = score.ToString();
        coinText.text = GameController.getCoins().ToString();
	}
}
