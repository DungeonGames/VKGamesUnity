const library = {
    $vkSDK:{
        bridge : undefined,

        isInitialized: false,

        vkWebAppInit: function(onInitializedCallback, onErrorCallback, isTest){
            const sdkScript = document.createElement('script');
            sdkScript.src = 'https://unpkg.com/@vkontakte/vk-bridge/dist/browser.min.js';
            document.head.appendChild(sdkScript);

            sdkScript.onload = function(){
                function invokeSuccess() {
                    vkSDK.isInitialized = true;
                    vkSDK.bridge = window['vkBridge'];
                    dynCall('v', onInitializedCallback);
                }

                function invokeFailure(error) {
                    dynCall('v', onErrorCallback);
                    console.error(error);
                }

                if (isTest) {
                    invokeSuccess();
                } else {
                    window['vkBridge'].send("VKWebAppInit", {})
                    .then(function (data) {
                        if (data.result) {
                            invokeSuccess();
                        } else {
                            invokeFailure(new Error('vkBridge failed to initialize.'));
                        }
                    })
                    .catch(function (error) {
                        invokeFailure(error);
                    });
                }
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

    WebAppInit: function(onInitializedCallback, onErrorCallback, isTest){
        isTest = !!isTest;
        vkSDK.vkWebAppInit(onInitializedCallback, onErrorCallback, isTest);
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
