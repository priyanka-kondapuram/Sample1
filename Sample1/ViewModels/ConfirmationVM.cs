using Sample1.Helper;
using Sample1.Views;

namespace Sample1.ViewModels
{
    public class ConfirmationVM : BaseViewModel
    {
        #region Public Constructors

        public ConfirmationVM()
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public override void PerformAction(string str)
        {
            Tools.TryInvokeOnMainThreadAsync(() =>
            {
                if (CurrentPage.Navigation.NavigationStack.Count >= 2)
                {
                    CurrentPage.Navigation.RemovePage(CurrentPage.Navigation.NavigationStack[CurrentPage.Navigation.NavigationStack.Count - 2]);
                }
                CurrentPage.Navigation.TryPopPage();
            });
        }

        #endregion Public Methods
    }
}