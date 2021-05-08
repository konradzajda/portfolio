// <copyright file="Startup.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api
{
    /// <summary>
    /// Startup class.
    /// </summary>
    public class Startup
    {
        private readonly IHostEnvironment environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="environment">Provides details about host's environment, see <see cref="IHostEnvironment"/>.</param>
        public Startup(IHostEnvironment environment)
        {
            this.environment = environment;
        }

        /// <summary>
        /// Configures dependency injection container.
        /// </summary>
        /// <param name="services">A collection of the services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApi();
            services.AddApplication();
            services.AddInfrastructure();
        }

        /// <summary>
        /// Configure middlewares.
        /// </summary>
        /// <param name="app">An application builder, see <see cref="IApplicationBuilder"/>.</param>
        public void Configure(IApplicationBuilder app)
        {
            if (this.environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                    c.SwaggerEndpoint(
                        "/swagger/v1/swagger.json",
                        ApiInfo.Name + " " + ApiInfo.Version));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}