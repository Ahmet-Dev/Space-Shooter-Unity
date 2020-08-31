using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketModel: MonoBehaviour {

    //Declares variable
    public Sprite rocketSprite;
    public int price;
    public int rocketId;
    private int status;
    public RocketModel(){
        rocketSprite = null;

        price = 0;
    }

    public Sprite getSprite(){
        return rocketSprite;
    }

    public int getPrice(){
        return price;
    }
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
    public void setStatus(int rocketId){
        PlayerPrefs.SetInt("RocketBuy" + rocketId.ToString(), 1);
    }

}
