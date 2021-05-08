// <copyright file="Startup.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api
{
    /// <inheritdoc />
    public class Startup : IStartup
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

        /// <inheritdoc/>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddApi();
            services.AddApplication();
            services.AddInfrastructure();

            return services.BuildServiceProvider();
        }

        /// <inheritdoc/>
        public void Configure(IApplicationBuilder app)
        {
            if (this.environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", ApiInfo.Name + " " + ApiInfo.Version));
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