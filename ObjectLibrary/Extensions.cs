using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;

namespace ObjectLibrary
{
    public static class Extensions
    {
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static SecureString Secure(this String str)
        {
             var secure = new SecureString();

            foreach (var c in str.ToCharArray()) 
                secure.AppendChar(c);
            return secure;
        }

        public static String Insecure(this SecureString str)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(str);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            } 
        }

        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> doWhat)
        {
            foreach (var item in collection)
            {
                doWhat(item);
            }
        }

        public static IEnumerable<T> OrEmptyIfNull<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }

        public static Task FixDates(this Task t)
        {
            var sqlMinDate = SqlDateTime.MinValue.Value;

            t.DueDate = (t.DueDate < sqlMinDate) ? sqlMinDate : t.DueDate;
            t.EndDate = (t.EndDate < sqlMinDate) ? sqlMinDate : t.EndDate;
            t.StartDate = (t.StartDate < sqlMinDate) ? sqlMinDate : t.StartDate;

            return t;
        }
    }
}