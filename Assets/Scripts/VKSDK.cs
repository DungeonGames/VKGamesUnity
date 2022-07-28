using System.Collections;
using System.Collections.Generic;
using AOT;
using System;
using UnityEngine;
using System.Runtime.InteropServices;

#if UNITY_WEBGL && !UNITY_EDITOR
using UnityEngine.Scripting;

[assembly: AlwaysLinkAssembly]
#endif

public class VKSDK : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void WebAppInit();
    [DllImport("__Internal")]
    private static extern void ShowRewardedAds(Action onRewardedCallback);
    [DllImport("__Internal")]
    private static extern void ShowInterstitialAds();
    [DllImport("__Internal")]
    private static extern void ShowLeaderboardBox(int playerScore);
    [DllImport("__Internal")]
    private static extern void ShowOrderBox(string itemType, string itemName);


    private void Start()
    {
        WebAppInit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            ShowInterstitialAds();

        if (Input.GetKeyDown(KeyCode.R))
            ShowRewardedAds(RewardedCallback);

        if (Input.GetKeyDown(KeyCode.L))
            ShowLeaderboardBox(100);

        if (Input.GetKeyDown(KeyCode.O))
            ShowOrderBox("test_type", "test_item");
    }


    [MonoPInvokeCallback(typeof(Action))]
    private static void RewardedCallback()
    {
        Debug.Log("reward get!");
    }
}
