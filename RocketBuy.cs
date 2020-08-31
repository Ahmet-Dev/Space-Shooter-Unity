using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketBuy : MonoBehaviour {

    //Declare variables
    public Image display;
    public RocketModel[] rockets;
    public int totalRockets;
    public int index = 0;

    public Text price;
    public Text coins;

    public Button buyButton;

	// Use this for initialization
	void Start () {

        //display.gameobject.setActive(true);
        display.sprite = rockets[0].getSprite();
        totalRockets = rockets.Length;
        coins.text = GameController.getCoins().ToString();

        if(rockets[0].getStatus() == 0){
            price.text = rockets[0].getPrice().ToString();
        }else{
            price.text = "0";

        }
	}
	
	// Update is called once per frame
	void Update () {
	}

    //shows the next rocket
    public void showNext(){

        if(index+1 <= totalRockets){
            index++;
            display.sprite = rockets[index].getSprite();

            if (rockets[index].getStatus() == 0)
            {
                price.text = rockets[index].getPrice().ToString();
            }
            else
            {
                price.text = "0";
                GameController.gamePlayingRocket = display.sprite;

            }

        }
    }

    //shows the previous rockets
    public void showPrevious(){

        if (index > 0)
        {
            index--;
            display.sprite = rockets[index].getSprite();

            if (rockets[index].getStatus() == 0)
            {
                price.text = rockets[index].getPrice().ToString();
            }
            else
            {
                price.text = "0";
                GameController.gamePlayingRocket = display.sprite;
            }

        }
    }

    //This method buy rockets
    public void buy(){
        
        if(rockets[index].price <= GameController.getCoins()){
            GameController.setCoins(GameController.getCoins() - rockets[index].price);
            rockets[index].price = 0;
            price.text = "0";
            GameController.gamePlayingRocket = display.sprite;
            rockets[index].setStatus(index);
        }
    }


}
