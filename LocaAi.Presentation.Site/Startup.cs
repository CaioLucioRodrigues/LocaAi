using KissLog;
using KissLog.Apis.v1.Listeners;
using KissLog.AspNetCore;
using LocaAi.Domain.Interfaces.Repositories;
using LocaAi.Infra.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LocaAi.Presentation.Site
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
            services.AddControllersWithViews();

            // TODO criar uma classe para a injeção de dependência
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(context => Logger.Factory.Get());
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            
            //TODO criar uma classe de configiração do log (LogConfig), incluir isso nos serviços dentro de uma Iterface 
            app.UseKissLogMiddleware(options =>
            {
                options.Listeners.Add(new KissLogApiListener(new KissLog.Apis.v1.Auth.Application(
                    Configuration["KissLog.OrganizationId"],
                    Configuration["KissLog.ApplicationId"])
                ));
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

