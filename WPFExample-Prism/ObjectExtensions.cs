using System;
using System.Collections.Generic;
using System.Text;

namespace WPfExample
{
    public static class ObjectExtensions
    {
        public static void PipeTo<TSource>(this TSource source, Action<TSource> action)
        {
            action?.Invoke(source);
        }

        public static TResult PipeTo<TSource, TResult>(this TSource source, Func<TSource, TResult> action)
        {
            return action(source);
        }
    }
}
