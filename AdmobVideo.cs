using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

public class AdmobVideo : MonoBehaviour {

    private RewardBasedVideoAd rewardBasedVideo;

    public Text reward;

    // set value how much reward will be rewarded after a succesful advertising
    public int videoReward;

    public static bool isAdLoaded = false;
    public static bool isRewarded = false;

    public Slider lifebar ;
    public GameObject continuePanel;
    public GameObject scorePanel;


    public void Start()
    {

        this.rewardBasedVideo = RewardBasedVideoAd.Instance;

        rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
 
        rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
 

        rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;

        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;

        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;

        this.RequestRewardBasedVideo();
    }

	private void Update()
	{

        if (rewardBasedVideo.IsLoaded())
        {
            isAdLoaded = true;
        }
	}


	public void RequestRewardBasedVideo()
    {

        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/5224354917";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/1712485313";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        AdRequest request = new AdRequest.Builder().Build();

        this.rewardBasedVideo.LoadAd(request, adUnitId);

       
    }



    public void adShow(){
        
        if (isAdLoaded)
        {

            this.rewardBasedVideo.Show();

        }
    }

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        isAdLoaded = true;
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log(
            "HandleRewardBasedVideoFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {


        if(!isRewarded){
            PlayerMove.instance.onCancel();
        }
        continuePanel.SetActive(false);

    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {

        isRewarded = true;
        addLife();
    }

    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {

        continuePanel.SetActive(false);
        isAdLoaded = false;
    }

    public void addLife()
    {

        lifebar.value += (videoReward / 100.0f);
        continuePanel.SetActive(false);
        Time.timeScale = 1;

    }
}
