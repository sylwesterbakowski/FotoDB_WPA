using FotoDB_WPA.Contexts;
using FotoDB_WPA.ILogic;
using FotoDB_WPA.Logic;
using FotoDB_WPA.Logic.Design_Patterns.Adapter;
using FotoDB_WPA.Logic.Design_Patterns.Decorator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB_WPA
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FotoDBContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddScoped<IKrajManager, KrajManager>();
            ///Testowanie wzorca Obserwator
            services.AddScoped<IAutorManager, AutorManager>();
            services.AddScoped<IFotoManager, FotoManager>();

            services.AddControllersWithViews();


            ///Testowanie wzorca Dekorator
            ///Rêczne dodawanie dekoratorów
            ///
            //services.AddScoped<KrajManager>();

            //services.AddScoped(krajProvider =>
            //{
            //    var memoryCache = krajProvider.GetService<IMemoryCache>();
            //    var logger = krajProvider.GetService<ILogger<KrajManagerLoggingDecorator>>();

            //    KrajManager krajManager = krajProvider.GetRequiredService<KrajManager>();

            //    IKrajManager cachingDecorator = new KrajManagerCachingDecorator(krajManager, memoryCache);
            //    IKrajManager loggingDecorator = new KrajManagerLoggingDecorator(krajManager, logger);

            //    return loggingDecorator;

            //});

            ///Dodawanie dekoratorów za pomoc¹ biblioteki Scrutor
            ///
            //services.Decorate<IKrajManager, KrajManagerCachingDecorator>();
            //services.Decorate<IKrajManager, KrajManagerLoggingDecorator>();


            ///Dodawanie dekoratorów za pomoc¹ biblioteki Scrutor w zale¿noœci od ustawieñ w pliku appsettings.json
            ///
            if (Convert.ToBoolean(Configuration["EnableCaching"]))
            {
                services.Decorate<IKrajManager, KrajManagerCachingDecorator>();
            }
            if (Convert.ToBoolean(Configuration["EnableLogging"]))
            {
                services.Decorate<IKrajManager, KrajManagerLoggingDecorator>();
                services.Decorate<IAutorManager, AutorManagerLoggingDecorator>();
            }

            ///Testowanie wzorca Adapter
            services.AddScoped<IAnalyticsService, AnalyticsService>();
            if (Convert.ToBoolean(Configuration["AdapterKlasowy"]))
            {
                services.AddScoped<IAnalyticsAdapter, AnalyticsAdapterKlasowy>();
            }
            else
            {
                services.AddScoped<IAnalyticsAdapter, AnalyticsAdapterObiektowy>();
            }
            




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
