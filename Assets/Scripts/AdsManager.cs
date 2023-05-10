using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
 
public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    [SerializeField] bool _testMode = true;
    private string _gameId;

    public enum AD_TYPE {
        INTERSTITIAL,
        REWARD,
        BANNER
    }
    [SerializeField] string _androidAdUnitIdIntersitial = "Interstitial_Android";
    [SerializeField] string _iOsAdUnitIdIntersitial = "Interstitial_iOS";
    string _adUnitIdIntersitial;
    [SerializeField] Button _showAdButtonReward;
    [SerializeField] string _androidAdUnitIdReward = "Rewarded_Android";
    [SerializeField] string _iOSAdUnitIdReward = "Rewarded_iOS";
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
        #elif UNITY_ANDROID
                _gameId = _androidGameId;
                _adUnitIdIntersitial = _androidAdUnitIdIntersitial;
                _adUnitIdReward = _androidAdUnitIdReward;
        #elif UNITY_EDITOR
                _gameId = _androidGameId; //Only for testing the functionality in the Editor
                _adUnitIdIntersitial = _androidAdUnitIdIntersitial;
                _adUnitIdReward = _androidAdUnitIdReward;
        #endif

        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(_gameId, _testMode, this);
        }

        // Disable the button until the ad is ready to show:
        _showAdButtonReward.interactable = false;
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
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        switch (thisType) {
            case AD_TYPE.INTERSTITIAL:
                Debug.Log("Loading Ad: " + _adUnitIdIntersitial);
                Advertisement.Load(_adUnitIdIntersitial, this);
                break;
            case AD_TYPE.REWARD:
                Debug.Log("Loading Ad: " + _adUnitIdReward);
                Advertisement.Load(_adUnitIdReward, this);
                break;
            case AD_TYPE.BANNER:
                break;
            default:
                break;
        }
    }
 
    // Show the loaded content in the Ad Unit:
    public void ShowAd(AD_TYPE thisType)
    {
        // Note that if the ad content wasn't previously loaded, this method will fail
        switch (thisType) {
            case AD_TYPE.INTERSTITIAL:
                Debug.Log("Showing Ad: " + _adUnitIdIntersitial);
                Advertisement.Show(_adUnitIdIntersitial, this);
                break;
            case AD_TYPE.REWARD:
                Debug.Log("Showing Ad: " + _adUnitIdReward);
                Advertisement.Show(_adUnitIdReward, this);
                break;
            case AD_TYPE.BANNER:
                break;
            default:
                break;
        }
    }
 
    // Implement Load Listener and Show Listener interface methods: 
    public void OnUnityAdsAdLoaded(string adUnitId)
    {   
        if (adUnitId == _adUnitIdIntersitial) {
            ShowAd(AD_TYPE.INTERSTITIAL);
        } else if (adUnitId == _adUnitIdReward) {
            ShowAd(AD_TYPE.REWARD);
        } else {

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
    public void OnUnityAdsShowComplete(string _adUnitId, UnityAdsShowCompletionState showCompletionState) { 
        Time.timeScale = 1;
    }
}
