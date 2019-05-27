using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MrnWebApi.Common.Routing;
using MrnWebApi.DataAccess.Inner.Scaffold.Entities;
using MrnWebApi.DataAccess.Services.Station;
using MrnWebApi.Logic.StationService;

namespace MrnWebApi
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
            RegisterCommonServices(services);
            RegisterLogicServices(services);
            RegisterDataAccessServices(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        private static void RegisterDataAccessServices(IServiceCollection services)
        {
            services.AddDbContext<MRN_developContext>();
            ////specific services
            services.AddTransient<IStationDataAccessService, DbStationDataAccessService>();
        }

        private static void RegisterLogicServices(IServiceCollection services)
        {
            services.AddTransient<IStationLogicService, StationLogicService>();
        }

        private static void RegisterCommonServices(IServiceCollection services)
        {
            services.AddTransient<UriRoute, UriRoute>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
