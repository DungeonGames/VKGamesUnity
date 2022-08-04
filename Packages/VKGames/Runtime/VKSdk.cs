using System;
using AOT;
using System.Runtime.InteropServices;

#if UNITY_WEBGL && !UNITY_EDITOR
using UnityEngine.Scripting;

[assembly: AlwaysLinkAssembly]
#endif

namespace Agava.VKGames
{
    public static class VKSdk
    {
        [DllImport("__Internal")]
        private static extern void WebAppInit(Action onSuccessCallback, Action onErrorCallback);
        [DllImport("__Internal")]
        private static extern bool IsInitialized();

        public static bool Initialized => IsInitialized();

        private static Action s_onSuccessCallback;
        private static Action s_onErrorCallback;

        public static void Initialize(Action onSuccessCallback = null, Action onErrorCallback = null)
        {
            s_onSuccessCallback = onSuccessCallback;
            s_onErrorCallback = onErrorCallback;

            WebAppInit(OnSuccessCallback, OnErrorCallback);
        }

        [MonoPInvokeCallback(typeof(Action))]
        private static void OnSuccessCallback()
        {
            s_onSuccessCallback.Invoke();
        }

        [MonoPInvokeCallback(typeof(Action))]
        private static void OnErrorCallback()
        {
            s_onErrorCallback?.Invoke();
        }

    }
}

