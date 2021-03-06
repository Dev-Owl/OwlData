﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OwlDataRun
{
    public static class ExtensionMethods
    {
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
            {
                action(item);
            }
        }
    }
}
