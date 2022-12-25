using AutoMapper;
using Serilog.Core;
using Serilog.Events;
using Serilog;
using Core.Utilities;
using Core.Constant;
using Service.IService;
using Service.Service;
using Repository.IRepository;
using Repository.Repository;

namespace BaseProject.Infrastructure
{
    public class DependencyRegister
    {
        public DependencyRegister(WebApplicationBuilder applicationBuilder)
        {
            ConfigurationManager configuration = applicationBuilder.Configuration;
            IServiceCollection services = applicationBuilder.Services;
            ConfigHelper.config = configuration;
            if (applicationBuilder.Environment.IsDevelopment())
                ConfigHelper.env = EnvirmenttStrings.IsDevelopment;
            else
                ConfigHelper.env = EnvirmenttStrings.IsProduction;
            #region Auto_Mapper
            IMapper mapper = MappingRegister.RegisterMaps().CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            #endregion
            #region Logs
            var levelSwitch = new LoggingLevelSwitch();
            levelSwitch.MinimumLevel = LogEventLevel.Information;
            services.AddLogging(builder =>
            {
                builder.AddConfiguration(configuration.GetSection("Serilog"))
                  .AddSerilog(new LoggerConfiguration().MinimumLevel.ControlledBy(levelSwitch).WriteTo.File($"logs\\logs-{DateTime.Now.ToString("D")}.log").CreateLogger())
                  .AddConsole();
                builder.AddDebug();
            });
            #endregion
            #region Cache Service
            services.AddMemoryCache();
            #endregion
            #region Repository
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            #endregion
            #region Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ResultModel>();
            #endregion


        }
    }
}
