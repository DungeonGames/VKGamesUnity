const library = {

    $vkSDK:{

        bridge : undefined,
        isInitialized: false,

        vkWebAppInit: function(onInitializedCallback){
            const sdkScript = document.createElement('script');
            sdkScript.src = 'https://unpkg.com/@vkontakte/vk-bridge/dist/browser.min.js';
            document.head.appendChild(sdkScript);

            sdkScript.onload = function(){
                console.log('1');
                dynCall('v', onInitializedCallback, []);
                console.log('2');
                // function invokeSuccess(callback) {
                //     console.log('3');
                //     vkSDK.isInitialized = true;
                //     vkSDK.bridge = window['vkBridge'];
                //     dynCall('v', callback, []);
                //     console.log('4');
                // }

                // function invokeFailure(callback, error) {
                //     console.log('5');
                //     dynCall('v', callback);
                //     console.error(error);
                //     console.log('6');
                // }

                // if (isTest) {
                //     console.log('1');
                //     invokeSuccess(onInitializedCallback);
                //     console.log('999');
                // } else {
                //     window['vkBridge'].send("VKWebAppInit", {})
                //     .then(function (data) {
                //         if (data.result) {
                //             invokeSuccess(onInitializedCallback);
                //         } else {
                //             invokeFailure(onFailedCallback, new Error('vkBridge failed to initialize.'));
                //         }
                //     })
                //     .catch(function (error) {
                //         invokeFailure(onFailedCallback, error);
                //     });
                // }
            }
           
        },

        // vkWebSAppShowRewardedAd: function(onRewardedCallback, onErrorCallback){
        //     vkSDK.bridge.send("VKWebAppShowNativeAds", {ad_format:"reward"})
        //     .then(function(data){
        //         if(data.result)
        //             dynCall('v', onRewardedCallback);
        //     })
        //     .catch(function (error) {
        //         dynCall('v', onErrorCallback);
        //         console.log(error);
        //     });
        // },

        // vkWebAppShowInterstitialAd: function(onOpenCallback, onErrorCallback)        {
        //     vkSDK.bridge.send("VKWebAppShowNativeAds", {ad_format:"interstitial"})
        //     .then(function (data) {
        //         if (data.result)
        //             dynCall('v', onOpenCallback);
        //     })
        //     .catch(function (error) {
        //         dynCall('v', onErrorCallback);
        //         console.log(error);
        //     });
        // },

        // vkWebAppShowLeaderboardBox: function(playerScore, onErrorCallback)
        // {
        //     vkSDK.bridge.send("VKWebAppShowLeaderBoardBox", {user_result:playerScore})
        //     .then(function (data) {
        //         console.log(data.success);
        //     })
        //     .catch(function (error) {
        //         dynCall('v', onErrorCallback);
        //         console.log(error);
        //     });
        // },
    },

    // C# calls

    WebAppInit: function(onInitializedCallback){
        vkSDK.vkWebAppInit(onInitializedCallback);
    },

    // ShowRewardedAds: function(onRewardedCallback, onErrorCallback){
    //     vkSDK.vkWebSAppShowRewardedAd(onRewardedCallback, onErrorCallback);
    // },

    // ShowInterstitialAds: function(onOpenCallback, onErrorCallback){
    //     vkSDK.vkWebAppShowInterstitialAd(onOpenCallback, onErrorCallback);
    // },

    // ShowLeaderboardBox: function(playerScore, onErrorCallback){
    //     vkSDK.vkWebAppShowLeaderboardBox(playerScore, onErrorCallback);
    // },

    IsInitialized: function () {
        return vkSDK.isInitialized;
    }

    
}

autoAddDeps(library, '$vkSDK');
mergeInto(LibraryManager.library, library);