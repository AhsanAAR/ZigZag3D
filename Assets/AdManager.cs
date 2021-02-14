using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{

    string App_ID;
    string Banner_ID;
    string Interstitial_ID;
    string Video_ID;

    private BannerView bannerView;


    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(App_ID);


        Banner_ID = "ca-app-pub-3940256099942544/6300978111";
        Interstitial_ID = "ca-app-pub-3940256099942544/1033173712";
        Video_ID = "ca-app-pub-3940256099942544/5224354917";
        this.RequestBanner();
    }

    private void RequestBanner()
    {

        this.bannerView = new BannerView(Banner_ID, AdSize.Banner, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
