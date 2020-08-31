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
        // Get singleton reward based video ad reference.
        this.rewardBasedVideo = RewardBasedVideoAd.Instance;

        // Called when an ad request has successfully loaded.
        rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // Called when an ad request failed to load.
        rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
         //Called when an ad is shown.

        rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
        //// Called when the ad starts to play.
        //rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
        //// Called when the user should be rewarded for watching a video.
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
        //// Called when the ad click caused the user to leave the application.
        //rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;
        //Request for a reward based video
        this.RequestRewardBasedVideo();
    }

	private void Update()
	{
        //whenever a video is loaded, set isLoaded true
        if (rewardBasedVideo.IsLoaded())
        {
            isAdLoaded = true;
        }
	}


	public void RequestRewardBasedVideo()
    {
        //Set your ad unit id here
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/5224354917";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/1712485313";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
        this.rewardBasedVideo.LoadAd(request, adUnitId);

       
    }


    //this method is called whren the loaded video needs to be shown
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
        //if the video is not watched fully, the user won't get any life

        if(!isRewarded){
            PlayerMove.instance.onCancel();
        }
        continuePanel.SetActive(false);

    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        //if the video is watched fully and rewarded, then set the bool true, and add some life
        isRewarded = true;
        addLife();
    }

    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        //close the panel when the video is playing 
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
