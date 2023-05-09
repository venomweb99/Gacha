using UnityEngine;
using UnityEngine.Advertisements;
 
public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    [SerializeField] bool _testMode = true;
    private string _gameId;
 
    [SerializeField] string _androidAdUnitIdIntersitial = "Interstitial_Android";
    [SerializeField] string _iOsAdUnitIdIntersitial = "Interstitial_iOS";
    string _adUnitIdIntersitial;

    void Awake()
    {
        InitializeAds();

        //_adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
          //  ? _iOsAdUnitId
           // : _androidAdUnitId;
    }
 
    public void InitializeAds()
    {
        #if UNITY_IOS
                _gameId = _iOSGameId;
        #elif UNITY_ANDROID
                _gameId = _androidGameId;
        #elif UNITY_EDITOR
                _gameId = _androidGameId; //Only for testing the functionality in the Editor
        #endif
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(_gameId, _testMode, this);
        }
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
    public void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + _adUnitIdIntersitial);
        Advertisement.Load(_adUnitIdIntersitial, this);
    }
 
    // Show the loaded content in the Ad Unit:
    public void ShowAd()
    {
        // Note that if the ad content wasn't previously loaded, this method will fail
        Debug.Log("Showing Ad: " + _adUnitIdIntersitial);
        Advertisement.Show(_adUnitIdIntersitial, this);
    }
 
    // Implement Load Listener and Show Listener interface methods: 
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        // Optionally execute code if the Ad Unit successfully loads content.
        ShowAd();
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
