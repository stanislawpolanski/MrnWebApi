using GeoAPI.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DatabaseAPI.Common.Routing;
using DatabaseAPI.DataAccess.Inner.Scaffold;
using DatabaseAPI.DataAccess.Services.Geometry;
using DatabaseAPI.DataAccess.Services.Photo;
using DatabaseAPI.DataAccess.Services.Railway;
using DatabaseAPI.DataAccess.Services.RailwayUnit;
using DatabaseAPI.DataAccess.Services.Station;
using DatabaseAPI.DataAccess.Services.StationToPhoto;
using DatabaseAPI.DataAccess.Services.StationToRailway;
using DatabaseAPI.DataAccess.Services.TypeOfAStation;
using DatabaseAPI.DataAccess.ServicesFactory;
using DatabaseAPI.Logic.StationService;
using DatabaseAPI.Logic.TypeOfAStationService;
using NetTopologySuite.IO;

namespace DatabaseAPI
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

        private void RegisterDataAccessServices(IServiceCollection services)
        {
            services.AddDbContext<MRN_developContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Database"), x => x.UseNetTopologySuite()));

            services.AddTransient<IStationDataAccessService, DbStationDataAccessService>();
            services.AddTransient<ITypeOfAStationDataAccessService, DbTypeOfAStationDataAccessService>();
            services.AddTransient<IRailwayDataAccessService, DbRailwayDataAccessService>();
            services.AddTransient<IPhotoDataAccessService, DbPhotoDataAccessService>();
            services.AddTransient<IRailwayUnitDataAccessService, DbRailwayUnitDataAccessService>();
            services.AddTransient<IGeometryDataAccessService, DbGeometryDataAccessService>();
            services.AddTransient<
                IStationToPhotoRelationshipDataAccessService, DbStationToPhotoRelationshipDataAccessService>();
            services.AddTransient<
                IStationToRailwayRelationshipDataAccessService, DbStationToRailwayRelationshipDataAccessService>();
        }

        private void RegisterLogicServices(IServiceCollection services)
        {
            services.AddTransient<IStationLogicService, StationLogicService>();
            services.AddTransient<ITypeOfAStationLogicService, TypeOfAStationLogicService>();
        }

        private void RegisterCommonServices(IServiceCollection services)
        {
            services.AddTransient<UriRoute, UriRoute>();
            services.AddTransient<ITextGeometryReader, WKTReader>();
            services.AddTransient<DataAccessServicesFactory, DataAccessServicesFactory>();
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
