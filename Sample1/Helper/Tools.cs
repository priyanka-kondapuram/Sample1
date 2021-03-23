using Sample1.Enums;
using Sample1.Models;
using Sample1.Views;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Sample1.Helper
{
    public static class Tools
    {
        #region Private Fields

        private static Dictionary<CViews, ContentView> _contentViews = new Dictionary<CViews, ContentView>();

        #endregion Private Fields

        #region Public Methods

        public static ContentView GetContentView(CViews contentView)
        {
            if (_contentViews.TryGetValue(contentView, out var view))
            {
                return view;
            }
            try
            {
                return contentView switch
                {
                    CViews.Home => _contentViews[contentView] = new HomeView(),
                    _ => throw new NotImplementedException("content view doesn't exist."),
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static NavigationPage MakeNavigationPage(this Page page) => new NavigationPage(page);

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

        #region Internal Methods

        internal static void TryInvokeOnMainThreadAsync(Action action)
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

        #endregion Internal Methods
    }
}