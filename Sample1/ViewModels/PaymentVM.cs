using Sample1.Enums;
using Sample1.Helper;
using Sample1.Views;
using System.Collections.Generic;

namespace Sample1.ViewModels
{
    public class PaymentVM : BaseViewModel
    {
        #region Public Fields

        public const string CHECKING_SAVING = "Checking/Savings Account";
        public const string CREDIT_CARD = "Credit Card";

        #endregion Public Fields

        #region Public Properties


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

        public PaymentVM()
        {
        }

        public override void PerformAction(string str)
        {
                var page = new ConfirmationPage();
                if (page != null && CurrentPage != page)
                {
                    CurrentPage?.Navigation?.TryPushPage(page);
                }
        }
        #endregion Public Constructors
    }
}