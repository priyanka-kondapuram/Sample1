using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sample1.MarkupExtensions
{
    [ContentProperty(nameof(Text))]
    public class TExtension : IMarkupExtension<BindingBase>
    {
        #region Public Properties

        public IValueConverter Converter { get; set; }

        public object ConverterParameter { get; set; }

        public string FormatParameter { get; set; }

        public string Text { get; set; }

        #endregion Public Properties

        //public string Text { get; set; }

        #region Public Methods

        public BindingBase ProvideValue(IServiceProvider serviceProvider)
        {
            if (!string.IsNullOrEmpty(FormatParameter))
            {
                return new Binding
                {
                    Mode = BindingMode.OneWay,
                    Path = $"[{Text}]",
                    Source = Translator.Instance,
                    Converter = Converter,
                    ConverterParameter = ConverterParameter,
                    StringFormat = "{0} " + FormatParameter
                };
            }
            return new Binding
            {
                Mode = BindingMode.OneWay,
                Path = $"[{Text}]",
                Source = Translator.Instance,
                Converter = Converter,
                ConverterParameter = ConverterParameter
            };
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => throw new NotImplementedException("TExtension IMarkupExtension.ProvideValue() is called.");

        #endregion Public Methods
    }
}