using ChronicleOnline.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ChronicleOnline.Converters
{
    public class StatusToColorConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is StatusType status)
            {
                return status switch
                {
                    StatusType.Exception => Colors.Red,
                    StatusType.NotClockedIn => Colors.Gray,
                    StatusType.ClockedIn => Colors.Green,
                    StatusType.PersonNotFound => Colors.Orange,
                    _ => Colors.Yellow
                };
            }

            return Colors.Pink;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
