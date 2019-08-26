using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Config;
using Repository.IoC;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.IO;

namespace Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            HostingEnvironment = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostingEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //SignalR
            services.AddSignalR();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            #region Configuração do Swagger
            if (!HostingEnvironment.IsProduction())
            {
                services.AddSwaggerGen(x =>
                {
                    x.SwaggerDoc("v1", new Info
                    {
                        Version = "v1",
                        Title = "Chart Template API",
                        Description = "Poc Chart"
                    });
                    x.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>()
                    {
                        { "bearer", new string[]{ } }
                    });
                    x.AddSecurityDefinition("bearer", new ApiKeyScheme { In = "header", Description = "Token JWT", Name = "Authorization", Type = "apiKey" });
                    
                });
            }
            #endregion

            #region Configuração do Cors CrossOrigins
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });

            services.Configure<MvcOptions>(options => {
                options.Filters.Add(new Microsoft.AspNetCore.Mvc.Cors.Internal.CorsAuthorizationFilterFactory("AllowAll"));
            });
            #endregion



            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            StartupIoC.RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            #region Configuração Swagger
            if (!env.IsProduction())
            {
                app.UseSwagger(x =>
                {
                    x.RouteTemplate = "swagger/{documentName}/swagger.json";
                });
                app.UseSwaggerUI(x =>
                {
                    x.SwaggerEndpoint("/swagger/v1/swagger.json", "Poc Chart API - V1");
                });
            }
            #endregion

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            //Cors
            app.UseCors("AllowAll");

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

            //SignalR
            app.UseSignalR(routes =>
            {
                routes.MapHub<ChartHub>("/chart");
            });
        }
    }
}
