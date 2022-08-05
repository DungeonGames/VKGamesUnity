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
        public IEnumerator ShouldInvokeErrorCallback()
        {
            bool callbackInvoked = false;

            VKSdk.Initialize(onErrorCallback: () =>
            {
                callbackInvoked = true;
            });


            yield return new WaitForSecondsRealtime(10);

            Assert.IsTrue(callbackInvoked);
        }
    }
}
