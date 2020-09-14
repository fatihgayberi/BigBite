using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronSourceScript_ : MonoBehaviour
{
    public DataManager dataManager;

    public static IronSourceScript_ Instante;
    private void Awake()
    {
        Instante = this;
    }
    private void Start()
    {
#if UNITY_ANDROID
        string appKey = "d3f5db65";
#elif UNITY_IPHONE
        string appKey = "d3f5a1dd";
#else
        string appKey = "unexpected_platform";
#endif

        Debug.Log("unity-script: IronSource.Agent.validateIntegration");
        IronSource.Agent.validateIntegration();

        Debug.Log("unity-script: unity version" + IronSource.unityVersion());

        // SDK init
        Debug.Log("unity-script: IronSource.Agent.init");
        IronSource.Agent.init(appKey);

        LoadInterstitial();
    }
    
    private void OnEnable()
    {
        //Add Rewarded Video Events
        IronSourceEvents.onRewardedVideoAdRewardedEvent += RewardedVideoAdRewardedEvent;
        // Add Interstitial DemandOnly Events
        IronSourceEvents.onInterstitialAdClosedEvent += InterstitialAdClosedEvent;
    }

    public void ShowReardedVideo()
    {
        if (IronSource.Agent.isRewardedVideoAvailable())
        {
            IronSource.Agent.showRewardedVideo();
        }
        else
        {
            Debug.Log("unity-script: IronSource.Agent.isRewardedVideoAvailable - False");
        }
    }

    public void ShowOfferwall()
    {
        if (IronSource.Agent.isOfferwallAvailable())
        {
            IronSource.Agent.showOfferwall();
        }
        else
        {
            Debug.Log("IronSource.Agent.isOfferwallAvailable - False");
        }
    }

    public void LoadInterstitial()
    {
        Debug.Log("unity-script: LoadInterstitialButtonClicked");
        IronSource.Agent.loadInterstitial();
    }

    public void ShowInterstitial()
    {
        Debug.Log("unity-script: ShowInterstitialButtonClicked");
        if (IronSource.Agent.isInterstitialReady())
        {
            IronSource.Agent.showInterstitial();
        }
        else
        {
            Debug.Log("unity-script: IronSource.Agent.isInterstitialReady - False");
        }
    }

    public void LoadBanner()
    {
        Debug.Log("unity-script: loadBannerButtonClicked");
        IronSource.Agent.loadBanner(IronSourceBannerSize.BANNER, IronSourceBannerPosition.BOTTOM);
    }

    public void DestroyBanner()
    {
        Debug.Log("unity-script: loadBannerButtonClicked");
        IronSource.Agent.destroyBanner();
    }
    /// <summary>
    /// callback handlers
    /// </summary>
    void RewardedVideoAdRewardedEvent(IronSourcePlacement ssp)
    {
        Debug.Log("unity-script: I got RewardedVideoAdRewardedEvent, amount = " + ssp.getRewardAmount() + " name = " + ssp.getRewardName());//Ödüllendirme.
        dataManager.Load(); 
        dataManager.data.totalCoin += 100;
        dataManager.Save();
    }
    void InterstitialAdClosedEvent()//Geçiş reklamı kapatıldığında ve kullanıcı uygulama ekranına geri döndüğünde çağrılır
    {
        Debug.Log("unity-script: I got InterstitialAdClosedEvent");
        LoadInterstitial();
    }
}
