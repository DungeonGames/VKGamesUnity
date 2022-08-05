using System.Collections;
using Agava.VKGames;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace VKGames.Tests
{
    public class InterstitialAdTests
    {
        [UnitySetUp]
public void Start()
        {
            VKSdk.Initialize();
        }

        [UnityTest]
        public IEnumerator ShowShouldInvokeErrorCallback()
        {
            bool callbackInvoked = false;
            Interstitial.Show(onErrorCallback: () =>
            {
                callbackInvoked = true;
            });

            yield return new WaitForSecondsRealtime(10);

            Assert.IsTrue(callbackInvoked);
        }
    }
}
