﻿using AutoMapper;
using LocaAi.Domain.Interfaces.Repositories;
using LocaAi.Domain.Interfaces.Services.Logging;
using LocaAi.Infra.Data.Context;
using LocaAi.Infra.Data.Repositories;
using LocaAi.Services.Log;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews();
            
            services.AddDbContext<LocaAiContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("LocaAiDb"), options => options.MaxBatchSize(10));
            });

            // TODO criar uma classe para a injeção de dependência
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ICaracteristicaRepository, CaracteristicaRepository>();
            services.AddScoped<ICaracteristicaOpcaoRepository, CaracteristicaOpcaoRepository>();
            services.AddScoped<ICaracteristicaPorCategoriaRepository, CaracteristicaPorCategoriaRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ILogServiceBase, LogServiceBase>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogServiceBase log)
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

            ILogServiceBase logging = app.ApplicationServices.GetService<ILogServiceBase>();
            logging.Configure(new object[] { app, Configuration });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

