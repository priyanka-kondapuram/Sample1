using Sample1.Enums;
using Sample1.Helper;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace Sample1.Converters
{
    public class ViewConverter : IValueConverter
    {
        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value switch
        {
            CViews contentView => ConvertContentViewEnumToView(contentView, parameter as string),
            _ => value,
        };

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

        #endregion Public Methods

        #region Private Methods

        private View ConvertContentViewEnumToView(CViews contentViewEnum, string parameter) => parameter switch
        {
            "MENU" => contentViewEnum != CViews.NULL ? Tools.GetContentView(contentViewEnum)?.Content : null,
            _ => null,
        };

        #endregion Private Methods
    }
}