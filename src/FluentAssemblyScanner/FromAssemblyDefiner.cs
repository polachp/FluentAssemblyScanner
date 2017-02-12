﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FluentAssemblyScanner
{
    /// <seealso cref="FluentAssemblyScanner.FromAssemblyDefinerBase" />
    public class FromAssemblyDefiner : FromAssemblyDefinerBase
    {
        /// <summary>
        ///     The non public types
        /// </summary>
        protected bool NonPublicTypes;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FromAssemblyDefiner" /> class.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        protected internal FromAssemblyDefiner(Assembly assembly)
            : base(new Assembly[] { assembly })
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FromAssemblyDefiner" /> class.
        /// </summary>
        /// <param name="assemblies">The assemblies.</param>
        protected internal FromAssemblyDefiner(IEnumerable<Assembly> assemblies)
            : base(assemblies)
        {
        }

        /// <summary>
        ///     Alls the types.
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Type> AllTypes()
        {
            AssemblyFilters?.Invoke(Assemblies);

            return Assemblies.SelectMany(a => a.GetAvailableTypesOrdered(NonPublicTypes));
        }

        /// <summary>
        ///     Excludes the assembly containing.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public FromAssemblyDefiner ExcludeAssemblyContaining<T>()
        {
            return ExcludeAssemblyNamed(typeof(T).Assembly.FullName);
        }

        /// <summary>
        ///     Excludes the assembly named.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <returns></returns>
        public FromAssemblyDefiner ExcludeAssemblyNamed(string assemblyName)
        {
            Assembly assembly = ReflectionUtil.GetAssemblyNamed(assemblyName);
            AssemblyFilters += assemblies => assemblies.Except(new[] { assembly });
            return this;
        }

        /// <summary>
        ///     Includes the non public types.
        /// </summary>
        /// <returns></returns>
        public FromAssemblyDefiner IncludeNonPublicTypes()
        {
            NonPublicTypes = true;
            return this;
        }
    }
}
