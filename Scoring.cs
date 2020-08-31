using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

    public static int score = 0;
    public Text scoreText;
    public Text coinText;
	void Start () {
        score = 0;
        coinText.text = GameController.getCoins().ToString();
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = score.ToString();
        coinText.text = GameController.getCoins().ToString();
	}
}
