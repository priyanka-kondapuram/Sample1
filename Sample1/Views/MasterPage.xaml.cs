﻿using Xamarin.Forms;

namespace Sample1.Views
{
    public partial class MasterPage : ContentPage
    {
        #region Public Constructors

        public MasterPage()
        {
            try
            {
                InitializeComponent();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        #endregion Public Constructors
    }
}