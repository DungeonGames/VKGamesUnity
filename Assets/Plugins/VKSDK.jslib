const library = {

    $vkSDK:{

        bridge : undefined,
        adsReady: false,

        vkWebAppInit: function(){
            const sdkScript = document.createElement('script');
            sdkScript.src = 'https://unpkg.com/@vkontakte/vk-bridge/dist/browser.min.js';
            document.head.appendChild(sdkScript);

            sdkScript.onload = function(){
                window['vkBridge'].send("VKWebAppInit", {})
                .then(data => console.log(data.result))
                .catch(error => console.log(error));
                vkSDK.bridge = window['vkBridge'];
            }
           
        },

        vkWebSAppShowRewardedAd: function(onVideoEnd){
            vkSDK.bridge.send("VKWebAppShowNativeAds", {ad_format:"reward"})
            .then(function(data){
                if(data.result)
                    dynCall('v', onVideoEnd);
            })
            .catch(error => console.log(error));
        },

        vkWebAppShowInterstitialAd: function()
        {
            vkSDK.bridge.send("VKWebAppShowNativeAds", {ad_format:"interstitial"})
            .then(data => console.log(data.result))
            .catch(error => console.log(error));
        },

        vkWebAppShowLeaderboardBox: function(playerScore)
        {
            vkSDK.bridge.send("VKWebAppShowLeaderBoardBox", {user_result:playerScore})
            .then(data => console.log(data.success))  
            .catch(error => console.log(error));
        },
        
        vkWebAppShowOrderBox: function(type, item){
            vkSDK.bridge.send("VKWebAppShowOrderBox", { 
                type: UTF8ToString(type),
                item: UTF8ToString(item)
              })
              .then(data => console.log(data.status))  
              .catch(error => console.log(error));
        }
    },

    // C# calls

    WebAppInit: function(){
        vkSDK.vkWebAppInit();
    },

    ShowRewardedAds: function(onVideoEnd){
        vkSDK.vkWebSAppShowRewardedAd(onVideoEnd);
    },

    ShowInterstitialAds: function(){
        vkSDK.vkWebAppShowInterstitialAd();
    },

    ShowLeaderboardBox: function(playerScore){
        vkSDK.vkWebAppShowLeaderboardBox(playerScore);
    },

    ShowOrderBox: function(type, item)
    {
        vkSDK.vkWebAppShowOrderBox(type, item);
    }
    
}

autoAddDeps(library, '$vkSDK');
mergeInto(LibraryManager.library, library);