﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Barcoder.WpfApp.Converters
{
    [ValueConversion(typeof(string), typeof(ImageSource))]
    public class StringToBarcodeImageConverter : BaseConverter, IValueConverter
    {
        public NetBarcode.Type Type { get; set; } = NetBarcode.Type.Code128;
        public bool ShowLabel { get; set; }

        private static NetBarcode.Barcode GetBarcode(string data, NetBarcode.Type type, bool showLabel)
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

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string data)
            {
                return GetBarcode(data, Type, ShowLabel)?.GetByteArray();
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
