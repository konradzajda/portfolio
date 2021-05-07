// <copyright file="ApplicationInfo.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using System.Reflection;

namespace Api
{
    internal static class ApplicationInfo
    {
        internal static Assembly[] MediatRAssemblies => new[]
        {
            Assembly.GetAssembly(typeof(ApplicationDependencyInjection)),
        };
    }
}