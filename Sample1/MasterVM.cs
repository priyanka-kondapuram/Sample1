using System.Windows.Input;
using Xamarin.Forms;

namespace Sample1
{
    public class MasterVM : BaseViewModel
    {
        #region Public Properties

        public ICommand Action { get; set; }

        public string CurrentVehicle
        {
            get => Get("");
            set => Set(value);
        }

        public Vehicle SelectedPickerItem
        {
            get => Get<Vehicle>();
            set
            {
                if (Set(value) && value != null)
                {
                    SelectedPickerItem = null;
                    CurrentVehicle = value.DisplayName;
                }
            }
        }

        #endregion Public Properties

        #region Public Constructors

        public MasterVM()
        {
            Action = new Command<object>(execute: (obj) =>
            {
                IsExecuting = true;
                PerformAction(obj);
                IsExecuting = false;
            }, canExecute: (obj) => !IsExecuting);
        }

        #endregion Public Constructors

        #region Private Methods

        private void PerformAction(object obj)
        {
            if (obj is Picker picker)
            {
                picker.Open();
            }
        }

        #endregion Private Methods
    }
}