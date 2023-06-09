using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;
using Unity.Services.Mediation;
using System.Threading.Tasks;
using System;
using Unity.Services.Core;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    [SerializeField] bool _testMode = false;
    private string _gameId;
    
    public enum AD_TYPE
    {
        INTERSTITIAL,
        REWARD,
        BANNER
    }
    [SerializeField] string _androidAdUnitIdIntersitial = "Interstitial_Android";
    [SerializeField] string _iOsAdUnitIdIntersitial = "Interstitial_iOS";
    string _adUnitIdIntersitial;
    [SerializeField] string _androidAdUnitIdReward = "Rewarded_Android";
    [SerializeField] string _iOSAdUnitIdReward = "Rewarded_iOS";

    [SerializeField] string _androidAdUnitIdBanner = "Banner_Android";
    [SerializeField] string _iOSAdUnitIdBanner = "Banner_iOS";
    string _adUnitIdBanner = null; // This will remain null for unsupported platforms.


    [SerializeField] BannerPosition _bannerPosition = BannerPosition.BOTTOM_CENTER;

    string _adUnitIdReward = null; // This will remain null for unsupported platforms

    void Awake()
    {
        InitializeAds();

        _adUnitIdIntersitial = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOsAdUnitIdIntersitial
            : _androidAdUnitIdIntersitial;
    }

    public void InitializeAds()
    {
#if UNITY_IOS
                        _gameId = _iOSGameId;
                        _adUnitIdIntersitial = _iOsAdUnitIdIntersitial;
                        _adUnitIdReward = _iOSAdUnitIdReward;
                        _adUnitIdBanner = _iOSAdUnitIdBanner;
                        
#elif UNITY_ANDROID
        _gameId = _androidGameId;
                        _adUnitIdIntersitial = _androidAdUnitIdIntersitial;
                        _adUnitIdReward = _androidAdUnitIdReward;
        _adUnitIdBanner = _androidAdUnitIdBanner;

#elif UNITY_EDITOR
                _gameId = _androidGameId; //Only for testing the functionality in the Editor
                _adUnitIdIntersitial = _androidAdUnitIdIntersitial;
                _adUnitIdReward = _androidAdUnitIdReward;
                _adUnitIdBanner = _androidAdUnitIdBanner;
#endif

        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Debug.Log("Iniciando ads");
            Advertisement.Initialize(_gameId, _testMode, this);
            // Configure the Load Banner button to call the LoadBanner() method when clicked:
            Advertisement.Banner.SetPosition(_bannerPosition);
        }

    }
    // Implement a method to call when the Load Banner button is clicked:
    public void LoadBanner()
    {
        Debug.Log("Loading banner...");
        // Set up options to notify the SDK of load events:
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };

        // Load the Ad Unit with banner content:
        Advertisement.Banner.Load(_adUnitIdBanner, options);
    }

    // Implement code to execute when the loadCallback event triggers:
    void OnBannerLoaded()
    {
        Debug.Log("Banner loaded");

        ShowBannerAd();
    }

    // Implement code to execute when the load errorCallback event triggers:
    void OnBannerError(string message)
    {
        Debug.Log($"Banner Error: {message}");
        // Optionally execute additional code, such as attempting to load another ad.
    }

    // Implement a method to call when the Show Banner button is clicked:
    void ShowBannerAd()
    {
        // Set up options to notify the SDK of show events:
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShown
        };

        // Show the loaded Banner Ad Unit:
        Advertisement.Banner.Show(_adUnitIdBanner, options);
    }

    // Implement a method to call when the Hide Banner button is clicked:
    public void HideBannerAd()
    {


        // Hide the banner:
        Advertisement.Banner.Hide();
    }

    public static void HideBannerAd_daily()
    {


        // Hide the banner:
        Advertisement.Banner.Hide();
    }

    void OnBannerClicked() { }
    void OnBannerShown() { }
    void OnBannerHidden() { }

    void OnDestroy()
    {

    }

    public bool IsInitialize()
    {
        Debug.Log("IsInitialize " + Advertisement.isInitialized);
        return Advertisement.isInitialized;
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    // Load content to the Ad Unit:
    public void LoadAd(AD_TYPE thisType)
    {
        Debug.Log("Loading Ad aaaa: " + thisType);
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        switch (thisType)
        {
            case AD_TYPE.INTERSTITIAL:
                Debug.Log("Loading Ad: " + _adUnitIdIntersitial);
                Advertisement.Load(_adUnitIdIntersitial, this);
                break;
            case AD_TYPE.REWARD:
                Debug.Log("Loading Ad: " + _adUnitIdReward);
                Advertisement.Load(_adUnitIdReward, this);
                break;
            case AD_TYPE.BANNER:
                Debug.Log("Loading Ad: " + _adUnitIdBanner);
                Advertisement.Banner.SetPosition(_bannerPosition);
                LoadBanner();
                break;
            default:
                break;
        }
    }
    // Show the loaded content in the Ad Unit:
    public void ShowAd(AD_TYPE thisType)
    {
        // Note that if the ad content wasn't previously loaded, this method will fail
        switch (thisType)
        {
            case AD_TYPE.INTERSTITIAL:
                Debug.Log("Showing Ad: " + _adUnitIdIntersitial);
                Advertisement.Show(_adUnitIdIntersitial, this);
                break;
            case AD_TYPE.REWARD:
                Debug.Log("Showing Ad: " + _adUnitIdReward);
                Advertisement.Show(_adUnitIdReward, this);
                break;
            case AD_TYPE.BANNER:
                Debug.Log("Showing Ad: " + _adUnitIdBanner);
                Advertisement.Show(_adUnitIdBanner, this);
                break;
            default:
                break;
        }
    }

    // Implement Load Listener and Show Listener interface methods: 
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        if (adUnitId == _adUnitIdIntersitial)
        {
            ShowAd(AD_TYPE.INTERSTITIAL);
        }
        else if (adUnitId == _adUnitIdReward)
        {
            ShowAd(AD_TYPE.REWARD);
        }
        else
        {
            Debug.Log("Ad Loaded: " + adUnitId);
            ShowAd(AD_TYPE.BANNER);
        }
    }

    public void OnUnityAdsFailedToLoad(string _adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {_adUnitId} - {error.ToString()} - {message}");
        // Optionally execute code if the Ad Unit fails to load, such as attempting to try again.
    }

    public void OnUnityAdsShowFailure(string _adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {_adUnitId}: {error.ToString()} - {message}");
        // Optionally execute code if the Ad Unit fails to show, such as loading another ad.
    }

    public void OnUnityAdsShowStart(string _adUnitId) { }
    public void OnUnityAdsShowClick(string _adUnitId) { }
    public void OnUnityAdsShowComplete(string _adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        Time.timeScale = 1;
        //check if exists PlayerPrefab
        if (GameObject.Find("PlayerPrefab") != null)
        {
            GameObject.Find("PlayerPrefab").GetComponent<PlayerController>().PauseMovememnt(true);
        }

        if (showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            Debug.Log("Ad Completed: " + _adUnitId);
            if (_adUnitId == _adUnitIdReward)
            {
                GameObject.Find("CoinSystem").GetComponent<CoinsSystem>().AddCoins(10);
            }
        }
        else if (showCompletionState == UnityAdsShowCompletionState.SKIPPED)
        {
            Debug.Log("Ad Skipped: " + _adUnitId);
        }
        else if (showCompletionState == UnityAdsShowCompletionState.UNKNOWN)
        {
            Debug.Log("Ad Failed: " + _adUnitId);
        }
    }
}
