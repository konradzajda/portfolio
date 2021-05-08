// <copyright file="ApiServiceCollectionExtensions.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using System;
using System.IO;

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
        private const string ApiDocsFileName = "portfolio_api.xml";

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
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, ApiDocsFileName));
            });

            services.AddMediatR(ApiInfo.MediatRAssemblies);
        }
    }
}