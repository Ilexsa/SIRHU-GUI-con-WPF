﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SIRHU.Validations
{
    public class SecureStringToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is SecureString secureString)
            {
                IntPtr ptr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(secureString);
                try
                {
                    return System.Runtime.InteropServices.Marshal.PtrToStringBSTR(ptr);
                }
                finally
                {
                    System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(ptr);
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string str)
            {
                SecureString secureString = new SecureString();
                foreach (char c in str)
                {
                    secureString.AppendChar(c);
                }
                return secureString;
            }
            return null;
        }
    }
}
