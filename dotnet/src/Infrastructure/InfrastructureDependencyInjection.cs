// <copyright file="InfrastructureDependencyInjection.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Contains extension methods for registering infrastructure layer's services in the dependency injection container.
    /// </summary>
    public static class InfrastructureDependencyInjection
    {
        /// <summary>
        /// Adds infrastructure's services.
        /// </summary>
        /// <param name="services">A collection of services, see <see cref="IServiceCollection"/>.</param>
        public static void AddInfrastructure(this IServiceCollection services)
        {
            // ignored
        }
    }
}