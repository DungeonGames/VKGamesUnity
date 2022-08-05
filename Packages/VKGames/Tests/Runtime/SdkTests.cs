using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Agava.VKGames;

namespace VKGames.Tests
{
    public class SdkTests
    {

        [UnityTest]
        public IEnumerator ShouldInitialize()
        {
            if (VKGamesSdk.Initialized)
            {
                Assert.IsTrue(true);
                yield break;
            }

            bool callbackInvoked = false;

            yield return VKGamesSdk.Initialize(onSuccessCallback: () =>
            {
                callbackInvoked = true;
            });


            yield return new WaitForSecondsRealtime(1);

            Assert.IsTrue(callbackInvoked);
        }
    }
}
