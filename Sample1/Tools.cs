using System;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Sample1
{
    public static class Tools
    {
        #region Public Methods

        public static NavigationPage MakeNavigationPage(this Page page) => new NavigationPage(page);
        internal static  void TryInvokeOnMainThreadAsync(Action action)
        {
            if (MainThread.IsMainThread)
            {
                try
                {
                    action?.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                MainThread.InvokeOnMainThreadAsync(() => TryInvokeOnMainThreadAsync(action));
            }
        }

        public static void Open(this Picker picker, [CallerMemberName] string caller = null)
        {
            try
            {
                if (DeviceInfo.Platform == DevicePlatform.Android)
                {
                    DependencyService.Get<IEffects>().OpenPicker(picker, "Cancel");
                }
                else
                {
                    _ = picker.Focus();
                }
            }
            catch (System.Exception ex)
            {
            }
        }
        #endregion Public Methods
    }
}