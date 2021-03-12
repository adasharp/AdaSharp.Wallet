using System;
using System.Collections.Generic;

namespace AdaSharp.Tests.Extensions
{
    public static class IntExtensions
    {
        public static void Times(this int value, Action action)
        {
            for (var index = 0; index < value; index++)
            {
                action();
            }
        }

        public static List<T> Times<T>(this int value, Func<T> action)
        {
            var toReturn = new List<T>();

            for (var index = 0; index < value; index++)
            {
                var resultFromAction = action.Invoke();

                toReturn.Add(resultFromAction);
            }

            return toReturn;
        }
    }
}