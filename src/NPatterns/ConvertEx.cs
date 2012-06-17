﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPatterns
{
    public static class ConvertEx
    {
        /// <summary>
        /// Convert the object to another type include nullable type.
        /// </summary>
        public static object ChangeType(object value, Type conversionType)
        {
            object obj;

            if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                var tmpType = Nullable.GetUnderlyingType(conversionType);
                object tmpObj = (conversionType == typeof(Guid)) ? new Guid(value.ToString()) : Convert.ChangeType(value, tmpType, null);
                obj = Activator.CreateInstance(conversionType, new object[] { tmpObj });
            }
            else
            {
                obj = (conversionType == typeof(Guid)) ? new Guid(value.ToString()) : Convert.ChangeType(value, conversionType, null);
            }

            return obj;
        }
    }
}
