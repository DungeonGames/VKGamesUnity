using System.Collections;
using DungeonGames.VKGames;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BannerAdTest : MonoBehaviour
{
    [UnitySetUp]
    public IEnumerator WaitForInitialization()
    {
        if (!VKGamesSdk.Initialized)
            yield return VKGamesSdk.Initialize(isTest: true);
    }

    [UnityTest]
    public IEnumerator ShowShouldInvokeErrorCallback()
    {
        bool callbackInvoked = false;
        
        BannerAd.Show(onErrorCallback: () =>
        {
            callbackInvoked = true;
        });

        yield return new WaitForSecondsRealtime(1);

        Assert.IsTrue(callbackInvoked);
    }
}