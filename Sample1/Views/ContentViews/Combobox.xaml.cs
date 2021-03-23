using Sample1.Helper;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sample1.Views.ContentViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Combobox : Grid
    {
        #region Public Fields

        public static readonly BindableProperty EnableOptionsProperty = BindableProperty.Create(nameof(EnableOptions), typeof(bool), typeof(Combobox), true);
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(double), typeof(Combobox), 12d);
        public static readonly BindableProperty LabelPaddingProperty = BindableProperty.Create(nameof(LabelPadding), typeof(Thickness), typeof(Combobox), new Thickness(10));
        public static readonly BindableProperty PlaceHolderProperty = BindableProperty.Create(nameof(PlaceHolder), typeof(string), typeof(Combobox), string.Empty);
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value), typeof(string), typeof(Combobox), string.Empty, BindingMode.TwoWay);

        #endregion Public Fields

        #region Private Fields

        private Picker _picker;

        #endregion Private Fields

        #region Public Properties

        public bool EnableOptions
        {
            get => (bool)GetValue(EnableOptionsProperty);
            set => SetValue(EnableOptionsProperty, value);
        }

        [TypeConverter(typeof(FontSizeConverter))]
        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public IList<string> Items { get; }

        public Thickness LabelPadding
        {
            get => (Thickness)GetValue(LabelPaddingProperty);
            set => SetValue(LabelPaddingProperty, value);
        }

        public string PlaceHolder
        {
            get => (string)GetValue(PlaceHolderProperty);
            set => SetValue(PlaceHolderProperty, value);
        }

        public string Value
        {
            get => (string)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        #endregion Public Properties

        #region Public Constructors

        public Combobox()
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Value))
            {
            }
        }

        #endregion Public Constructors

        #region Private Methods

        private void FalconCombobox_ChildAdded(object sender, ElementEventArgs e)
        {
            if (e.Element is Picker picker)
            {
                _picker = picker;
                picker.Unfocused += Picker_Unfocused;
            }
        }

        private void Picker_Unfocused(object sender, FocusEventArgs e)
        {
            frame.SetAppThemeColor(Frame.BackgroundColorProperty, light: Color.Gray, dark: Color.LightGray);
            frame.SetAppThemeColor(Frame.BorderColorProperty, light: Color.Gray, dark: Color.LightGray);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (EnableOptions)
            {
                frame.BorderColor = Color.Blue;
                frame.BackgroundColor = Color.Blue;
                _picker.Open();
            }
        }

        #endregion Private Methods
    }
}