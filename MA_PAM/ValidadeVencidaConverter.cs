using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace MA_PAM
{
    public class ValidadeVencidaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime validade)
            {
                return validade < DateTime.Now ? Colors.Red : Colors.Black;
            }

            return Colors.Gray; // caso a validade seja nula ou inválida
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
