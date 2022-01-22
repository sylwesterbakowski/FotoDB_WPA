using FotoDB_WPA.Contexts;
using FotoDB_WPA.ILogic;
using FotoDB_WPA.Logic;
using FotoDB_WPA.Logic.Design_Patterns.Adapter;
using FotoDB_WPA.Logic.Design_Patterns.Builder;
using FotoDB_WPA.Logic.Design_Patterns.Decorator;
using FotoDB_WPA.Logic.Design_Patterns.Singleton;
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
            if (Convert.ToBoolean(Configuration["BazaSingleton"]))
            {
                services.AddDbContext<FotoDBContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("Default")), ServiceLifetime.Singleton);
            }
            else
            {
                services.AddDbContext<FotoDBContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            }
            //services.AddDbContext<FotoDBContext>
            //    (options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            //services.AddDbContext<FotoDBContext>
            //    (options => options.UseSqlServer(Configuration.GetConnectionString("Default")), ServiceLifetime.Singleton);

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

            ///Testowanie wzorca Builder
            services.AddScoped<IPlanWystawyBuilder, PermanentPlanWystawyBuilder>();
            services.AddScoped<IPlanWystawyBuilder, TemporaryPlanWystawyBuilder>();

            services.AddScoped<IPlanWystawyDirector, PlanWystawyDirector>();

            ///Testowanie wzorca Singleton
            ///
           
            Console.WriteLine("Próba utworzenia: Singleton klasyczny nr 1");
            ISingleton clasicSingleton1 = ClasicSingleton.Instance;
            Console.WriteLine("Próba utworzenia: Singleton klasyczny nr 2");
            ISingleton clasicSingleton2 = ClasicSingleton.Instance;
            if (clasicSingleton1 == clasicSingleton2)
            {
                Console.WriteLine("Oba wskaŸniki na Singletony klasyczne wskazuj¹ na t¹ sam¹ instancjê, czyli utworzono tylko jedn¹ instancjê Singletona klasycznego");
            }

            Console.WriteLine("Próba utworzenia: Singleton lazy nr 1");
            ISingleton lazySingleton1 = LazySingleton.Instance;
            Console.WriteLine("Próba utworzenia: Singleton lazy nr 2");
            ISingleton lazySingleton2 = LazySingleton.Instance;
            if (lazySingleton1 == lazySingleton2)
            {
                Console.WriteLine("Oba wskaŸniki na Singletony lazy wskazuj¹ na t¹ sam¹ instancjê, czyli utworzono tylko jedn¹ instancjê Singletona lazy");
            }
            if (clasicSingleton1 == lazySingleton2)
            {
                Console.WriteLine("Singleton klasyczny i Singleton lazy maj¹ tak¹ sam¹ instancjê, wiêc jest tylko jeden Sigleton");
            }
            else
            {
                Console.WriteLine("Singleton klasyczny i Singleton lazy maj¹ ró¿ne instancje, wiêc s¹ utworzone dwa ró¿ne Sigletony");
            }


            //services.AddSingleton<ClasicSingleton>();
            //services.AddSingleton<LazySingleton>();

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
