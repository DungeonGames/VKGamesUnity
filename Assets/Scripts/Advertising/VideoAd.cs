using AOT;
using System;
using System.Runtime.InteropServices;

namespace Agava.VKSdk
{
    public static class VideoAd
    {
        [DllImport("__Internal")]
        private static extern void ShowRewardedAds(Action onRewardedCallback, Action onErrorCallback);

        private static Action s_onRewardedCallback;
        private static Action s_onErrorCallback;

        public static void Show(Action rewardedCallback = null, Action errorCallback = null)
        {
            s_onRewardedCallback = rewardedCallback;
            s_onErrorCallback = errorCallback;

            ShowRewardedAds(OnRewardedCallback, OnErrorCallback);
        }


        [MonoPInvokeCallback(typeof(Action))]
        private static void OnRewardedCallback()
        {
            s_onRewardedCallback?.Invoke();
        }

        [MonoPInvokeCallback(typeof(Action))]
        private static void OnErrorCallback()
        {
            s_onErrorCallback?.Invoke();
        }
    }
}
