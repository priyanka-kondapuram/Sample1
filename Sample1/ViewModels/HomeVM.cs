﻿using Sample1.Helper;
using Sample1.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace Sample1.ViewModels
{
    public class HomeVM : BaseViewModel
    {
        #region Public Properties

        public ICommand PickerAction { get; set; }
        public string CurrentVehicle { get => Get(""); set => Set(value); }
        public MasterVM ParentVM { get; set; }

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

        public HomeVM()
        {
            PickerAction = new Command<object>(execute: (obj) =>
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