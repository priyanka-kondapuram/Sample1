using Sample1.Enums;
using Sample1.Models;
using Sample1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Sample1.Helper
{
    public static class Tools
    {
        #region Private Fields

        private static Dictionary<CViews, ContentView> _contentViews = new Dictionary<CViews, ContentView>();

        private static bool _pop = true;

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

        public static async void TryPopPage(this INavigation navigation, bool isModalPage = false, [CallerMemberName] string caller = null)
        {
            if (!_pop)
            {
                return;
            }
            _pop = false;
            try
            {
                if (MainThread.IsMainThread)
                {
                    if (isModalPage)
                    {
                        _ = await navigation.PopModalAsync().ConfigureAwait(false);
                    }
                    else
                    {
                        _ = await navigation.PopAsync().ConfigureAwait(false);
                    }
                    _pop = true;
                }
                else
                {
                    await MainThread.InvokeOnMainThreadAsync(() =>
                    {
                        _pop = true;
                        navigation.TryPopPage(isModalPage);
                        _pop = false;
                    }).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                _pop = true;
            }
        }

        public static async void TryPushPage(this INavigation navigation, Page page, bool isModalPage = false, bool animation = true, [CallerMemberName] string caller = null, bool fromModal = false)
        {
            try
            {
                var p = App.Current.MainPage;
                var nav = ((NavigationPage)p).Navigation;
                if ((fromModal && nav.ModalStack.LastOrDefault()?.GetType() == page.GetType()) || (!fromModal && nav.NavigationStack.LastOrDefault().GetType() == page.GetType()))
                {
                    return;
                }
                if (MainThread.IsMainThread)
                {
                    if (isModalPage)
                    {
                        await navigation.PushModalAsync(page, animation).ConfigureAwait(false);
                        return;
                    }
                    await navigation.PushAsync(page, animation).ConfigureAwait(false);
                }
                else
                {
                    await MainThread.InvokeOnMainThreadAsync(() => navigation.TryPushPage(page, isModalPage)).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
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