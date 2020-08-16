using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterAdManager : MonoBehaviour
{
    public static InterAdManager instance;

    private InterstitialAd interstitial;

    private void Awake()
    {
        instance = this;

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        if (interstitial == null || !interstitial.IsLoaded())
            RequestInterstitial();
    }

    public void RequestInterstitial()
    {

#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string adUnitId = "boş";
#else
        string adUnitId = "unexpected_platform";
#endif

        this.interstitial = new InterstitialAd(adUnitId);

        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        this.interstitial.OnAdClosed += HandleOnAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
    }

    private void HandleOnAdClosed(object sender, EventArgs e)
    {
        RequestNewInterstitial();
    }

    private void HandleOnAdOpened(object sender, EventArgs e)
    {
    }

    private void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs e)
    {
        RequestNewInterstitial();
    }

    private void RequestNewInterstitial()
    {
        AdRequest request = new AdRequest.Builder()
            .Build();

        interstitial.LoadAd(request);
    }

    public bool ShowAd()
    {
        if (interstitial.IsLoaded())
        {
            interstitial?.Show();
            RequestNewInterstitial();
            return true;
        }

        RequestNewInterstitial();
        return false;
    }
}
