// <copyright file="ApiInfo.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

namespace Api
{
    /// <summary>
    /// Provides global information about API itself.
    /// </summary>
    internal static class ApiInfo
    {
        /// <summary>
        /// Gets all assemblies containing MediatR related classes.
        /// </summary>
        internal static Assembly[] MediatRAssemblies => new[]
        {
            Assembly.GetAssembly(typeof(ApplicationDependencyInjection)),
        };
    }
}