using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.VKSDK;
using UnityEngine.UI;

public class PlaytestingCanvas : MonoBehaviour
{
    [SerializeField] private Text _coinsAmountText;

    private int _coinsAmount = 0;

    public void InitilizeSDKButton()
    {
        VKSDK.Initialize(onSuccessCallback: OnSDKInitilized);
    }

    private void OnSDKInitilized()
    {
        Debug.Log(VKSDK.Initialized);
    }

    public void ShowInterstitialButton()
    {
        Interstitial.Show();
    }

    public void ShowRewardedAdsButton()
    {
        VideoAd.Show(rewardedCallback: OnRewardedCallback);
    }

    private void OnRewardedCallback()
    {
        _coinsAmount += 40;
        _coinsAmountText.text = $"{_coinsAmount} coins";
    }

    public void ShowLeaderboardButton()
    {
        Leaderboard.ShowLeaderboard(100);
    }

    public void ShowIAPWindow()
    {
        InAppPurchases.Buy("item1", "item1");
    }

}
