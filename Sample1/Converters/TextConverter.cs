using Sample1.Views.ContentViews;
using System.Globalization;
using Xamarin.Forms;

namespace Sample1.Converters
{
    public class TextConverter : IValueConverter
    {
        #region Public Methods

        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture) => parameter switch
        {
            Combobox combobox => ConvertComboboxToString(value, combobox),
            _ => value,
        };

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture) => value;

        #endregion Public Methods

        #region Private Methods

        private object ConvertComboboxToString(object value, Combobox combobox)
        {
            if (string.IsNullOrEmpty(value?.ToString()))
            {
                return combobox.PlaceHolder;
            }
            return value;
        }

        #endregion Private Methods
    }
}