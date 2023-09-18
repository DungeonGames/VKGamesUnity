using System;
using System.Runtime.InteropServices;
using AOT;
using UnityEngine;

namespace DungeonGames.VKGames
{
    public class BannerAd : MonoBehaviour
    {
        [DllImport("__Internal")]
        private static extern void ShowBannerAd(Action onErrorCallback);

        private static Action s_onErrorCallback;

        public static void Show(Action onErrorCallback = null)
        {
            s_onErrorCallback = onErrorCallback;
            
            ShowBannerAd(OnErrorCallback);
        }
        
        [MonoPInvokeCallback(typeof(Action))]
        private static void OnErrorCallback()
        {
            s_onErrorCallback?.Invoke();
        }
    }
}