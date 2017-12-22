using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CMS.Delivery.Providers;
using CMS.Delivery.Web.Providers;
using CMS.Delivery.Providers.DD4T;

namespace CMS.Delivery.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddSingleton<IIdentityManager, IdentityManager>();
            services.AddTransient<IContextProvider, DefaultContextProvider>();

            services.AddSingleton<ICompositionResolver, DD4TCompositionResolverProvider>();
            services.AddSingleton<ICompositionProvider, DD4TCompositionResolverProvider>();

            //services.AddSingleton<ILayoutProvider, DefaultLayoutProvider>();
            //services.AddSingleton<IContentProvider, DefaultContentProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{*uri}",
                    defaults: new { controller = "Home", action = "Index" }
                );
            });

            var identityManager = app.ApplicationServices.GetService<IIdentityManager>();
            identityManager.Seed();
        }
    }
}
