using Sample1.Enums;
using Sample1.Views;
using System.Collections.Generic;

namespace Sample1.ViewModels
{
    public class MasterVM : BaseViewModel
    {
        #region Public Fields

        public const string CHECKING_SAVING = "Checking/Savings Account";
        public const string CREDIT_CARD = "Credit Card";

        #endregion Public Fields

        #region Public Properties

        public CViews CurrentView { get => Get(CViews.Home); set => Set(value); }

        public HomeVM HomeVM { get; set; }

        public List<KeyValuePair<string, string>> PaymentTypes { get; set; } = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>(CREDIT_CARD,"CC"),
            new KeyValuePair<string, string>(CHECKING_SAVING,"C/S")
        };

        public KeyValuePair<string, string> SelectedPaymentType
        {
            get => Get(PaymentTypes[0]);
            set
            {
                if (Set(value))
                {
                    //ClearPaymentTypeObjects();
                }
            }
        }

        #endregion Public Properties

        #region Public Constructors

        public MasterVM()
        {
            HomeVM = new HomeView().Content.BindingContext as HomeVM;
            HomeVM.ParentVM = this;
        }

        #endregion Public Constructors
    }
}