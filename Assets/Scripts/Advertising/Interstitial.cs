using System.Runtime.InteropServices;
using System;
using AOT;

namespace Agava.VKSdk
{
    public static class Interstitial
    {
        [DllImport("__Internal")]
        private static extern void ShowInterstitialAds(Action onSuccesCallback, Action onErrorCallback);

        private static Action s_onSuccessCallback;
        private static Action s_onErrorCallback;

        public static void Show(Action onSuccessCallback = null, Action onErrorCallback = null)
        {
            s_onSuccessCallback = onSuccessCallback;
            s_onErrorCallback = onErrorCallback;

            ShowInterstitialAds(OnSuccessCallback, OnErrorCallback);
        }

        [MonoPInvokeCallback(typeof(Action))]
        private static void OnSuccessCallback()
        {
            s_onSuccessCallback?.Invoke();
        }

        [MonoPInvokeCallback(typeof(Action))]
        private static void OnErrorCallback()
        {
            s_onErrorCallback?.Invoke();
        }

    }
}