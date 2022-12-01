﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ConvenienceStore
{
  
        public class BoolToVisibilityConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value is int)
                {
                    if ((int)value == 1)
                        return "Visible";
                    else if ((int)value == 0) return "Hidden";
                }
                return "Hidden";
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if ((string)value == "Visible")
                    return 1;
                else if ((string)value == "Hidden") return 0;
                else return 0;
            }
        }
    
}