// <copyright file="ApplicationDependencyInjection.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Contains extension methods for registering application layer's services in the dependency injection container.
    /// </summary>
    public static class ApplicationDependencyInjection
    {
        /// <summary>
        /// Adds application's services.
        /// </summary>
        /// <param name="services">A collection of services, see <see cref="IServiceCollection"/>.</param>
        public static void AddApplication(this IServiceCollection services)
        {
            // ignored
        }
    }
}