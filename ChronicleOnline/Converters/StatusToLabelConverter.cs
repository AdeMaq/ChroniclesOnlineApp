using ChronicleOnline.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ChronicleOnline.Converters
{
    public class StatusToLabelConverter:IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is StatusType status)
            {
                return status switch
                {
                    StatusType.Exception => "Exception",
                    StatusType.NotClockedIn => "Not Clocked In",
                    StatusType.ClockedIn => "Clocked In",
                    _ => "Unknown"
                };
            }
            return string.Empty;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
