using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketModel: MonoBehaviour {

    //Declares variable
    public Sprite rocketSprite;
    public int price;
    public int rocketId;
    private int status;

    //Constructor 
    public RocketModel(){
        rocketSprite = null;

        price = 0;
    }

    // Sprite getter method
    public Sprite getSprite(){
        return rocketSprite;
    }

    //Sprite setter method
    public int getPrice(){
        return price;
    }

    //Returns an integer, which indicates if the rocket is bought or not
    public int getStatus(){
        
        if (PlayerPrefs.GetInt("RocketBuy" + rocketId.ToString()) == 0)
        {
             status = 0;
        }
        else
        {
            status = 1;
        }

        Debug.Log(rocketId.ToString() + PlayerPrefs.GetInt("RocketBuy" + rocketId.ToString()));

        return status;
    }

    //Set status
    public void setStatus(int rocketId){
        PlayerPrefs.SetInt("RocketBuy" + rocketId.ToString(), 1);
    }

}
