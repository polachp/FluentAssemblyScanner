﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentAssemblyScanner
{
    internal static class FunctionExtensions
    {
        /// <summary>
        ///     Whereifies the specified predicate funcs.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <param name="predicateFuncs">The predicate funcs.</param>
        /// <returns></returns>
        public static IEnumerable<T> Whereify<T>(this IEnumerable<T> @this, IEnumerable<Func<T, bool>> predicateFuncs)
        {
            IEnumerator<T> enumerator = @this.GetEnumerator();
            while (enumerator.MoveNext())
            {
                T currentObject = enumerator.Current;

                if (predicateFuncs.As<IEnumerable<Func<T, bool>>>().All(x => x.Invoke(currentObject)))
                {
                    yield return currentObject;
                }
            }
        }
    }
}
