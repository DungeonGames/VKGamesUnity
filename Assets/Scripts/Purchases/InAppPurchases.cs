using System.Runtime.InteropServices;

namespace Agava.VKSDK
{
    public static class InAppPurchases
    {

        [DllImport("__Internal")]
        private static extern void ShowOrderBox(string itemType, string itemName);

        public static void Buy(string itemType = null, string itemName = null)
        {
            ShowOrderBox(itemType, itemName);
        }
    }
}

