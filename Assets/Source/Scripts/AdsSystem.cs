using AppodealStack.Monetization.Api;
using AppodealStack.Monetization.Common;

public class AdsSystem : GameSystem
{
    private const string APP_KEY = "YOUR_APPODEAL_APP_KEY";

    public override void OnStart()
    {
        Appodeal.Initialize(APP_KEY, AppodealAdType.Interstitial);

        _gameData.RestartSignal.AddListener(ShowInterstitial);
    }

    private void ShowInterstitial()
    {
        if (!Appodeal.IsLoaded(AppodealAdType.Interstitial)) return;

        Appodeal.Show(AppodealShowStyle.Interstitial);
    }
}