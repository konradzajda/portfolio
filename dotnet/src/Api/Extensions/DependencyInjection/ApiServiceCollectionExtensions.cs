// <copyright file="ApiServiceCollectionExtensions.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using Api;
using MediatR;
using Microsoft.OpenApi.Models;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Contains extension methods for registering presentation layer's services in the dependency injection container.
    /// </summary>
    internal static class ApiServiceCollectionExtensions
    {
        /// <summary>
        /// Adds API's services.
        /// </summary>
        /// <param name="services">A collection of services, see <see cref="IServiceCollection"/>.</param>
        internal static void AddApi(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = ApiInfo.Name, Version = "v1",
                    });
            });

            services.AddMediatR(ApiInfo.MediatRAssemblies);
        }
    }
}