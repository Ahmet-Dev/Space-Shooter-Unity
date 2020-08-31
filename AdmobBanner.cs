using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;


public class AdmobBanner : MonoBehaviour {

    private BannerView bannerView;

    public void Start()
    {
        #if UNITY_ANDROID
            string appId = "ca-app-pub-8189631942477978~7318796369";

        #elif UNITY_IPHONE
            string appId = "ca-app-pub-3940256099942544~1458002511";

        #else
            string appId = "unexpected_platform";
        #endif

        MobileAds.Initialize(appId);

        this.RequestBanner();
    }

    private void RequestBanner()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-8189631942477978/3289596601";

        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";

        #else
            string adUnitId = "unexpected_platform";

        #endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);

        //bannerView.Show();

    }

    public void destroyAdd(){
        bannerView.Destroy();
    }
}
