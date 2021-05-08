// <copyright file="ApiInfo.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using System;
using System.Reflection;

using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
    /// <summary>
    /// Provides global information about API itself.
    /// </summary>
    internal static class ApiInfo
    {
        /// <summary>
        /// Name of the API.
        /// </summary>
        internal const string Name = "Portfolio";

        /// <summary>
        /// Gets all assemblies containing MediatR related classes.
        /// </summary>
        internal static Assembly[] MediatRAssemblies => new[]
        {
            Assembly.GetAssembly(typeof(ApplicationDependencyInjection)),
        };

        /// <summary>
        /// Gets all <see cref="Profile"/> types in the solution.
        /// </summary>
        internal static Type[] MapperProfiles => new[]
        {
            typeof(ApiProfile),
            typeof(ApplicationProfile),
        };

        /// <summary>
        /// Gets version of the API's project.
        /// </summary>
        internal static string Version => Assembly.GetAssembly(typeof(ApiInfo))?.GetName().Version?.ToString();
    }
}