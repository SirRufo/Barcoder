using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Barcoder.WpfApp.Converters
{
    public class StringToBarcodeConverter : IValueConverter
    {
        private static NetBarcode.Barcode? GetBarcode(string data, NetBarcode.Type type, bool showLabel)
        {
            try
            {
                return new NetBarcode.Barcode(data, type, showLabel);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string s)
            {
                NetBarcode.Barcode? bc = parameter switch
                {
                    string strpar when Enum.TryParse<NetBarcode.Type>(strpar, out var bt) => GetBarcode(s, bt, true),
                    NetBarcode.Type t => GetBarcode(s, t, true),
                    _ => new NetBarcode.Barcode(s, true),
                };
                return bc?.GetByteArray();
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class BaseConverter : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
