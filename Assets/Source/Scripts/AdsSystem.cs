using AppodealStack.Monetization.Api;
using AppodealStack.Monetization.Common;
using Supyrb;
using UnityEngine;

public class AdsSystem : GameSystem
{
    [SerializeField] private string _appKey;

    public override void OnStart()
    {
        Appodeal.Initialize(_appKey, AppodealAdType.Interstitial);

        Signals.Get<OnGameRestartedSignal>().AddListener(ShowInterstitial);
    }

    private void ShowInterstitial()
    {
        if (!Appodeal.IsLoaded(AppodealAdType.Interstitial)) return;

        Appodeal.Show(AppodealShowStyle.Interstitial);
    }
}