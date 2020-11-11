using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sample1.MarkupExtensions
{
    [ContentProperty(nameof(Text))]
    public class PDExtension : IMarkupExtension<BindingBase>
    {
        #region Public Properties

        public IValueConverter Converter { get; set; }
        public object ConverterParameter { get; set; }
        public object FallbackValue { get; set; }
        public string StringFormat { get; set; }
        public object TargetNullValue { get; set; }
        public string Text { get; set; }

        #endregion Public Properties

        #region Public Methods

        public BindingBase ProvideValue(IServiceProvider serviceProvider)
        {
            var binding = new Binding
            {
                Mode = BindingMode.OneWay,
                Path = $"{Text}",
                Source = AppValues.Instance,
                StringFormat = StringFormat,
                Converter = Converter,
                ConverterParameter = ConverterParameter,
                TargetNullValue = TargetNullValue,
                FallbackValue = FallbackValue
            };
            return binding;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => throw new NotImplementedException("PDExtension IMarkupExtension.ProvideValue() is called.");

        #endregion Public Methods
    }
}