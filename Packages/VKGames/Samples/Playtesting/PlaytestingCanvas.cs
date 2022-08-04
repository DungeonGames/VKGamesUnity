using UnityEngine;
using Agava.VKGames;
using UnityEngine.UI;

public class PlaytestingCanvas : MonoBehaviour
{
    [SerializeField] private Text _coinsAmountText;

    private int _coinsAmount = 0;

    public void InitilizeSDKButton()
    {
        VKSdk.Initialize(onSuccessCallback: OnSDKInitilized);
    }

    private void OnSDKInitilized()
    {
        Debug.Log(VKSdk.Initialized);
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
}
