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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using UnitofWork;
using Microsoft.IdentityModel.Tokens;

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
            #region Swagger_Setting
            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "INDEXING API - V1",
                    Version = "v1",
                    License = new OpenApiLicense { Name = "Microsoft ASP.NET Core" },
                    Description = "FINOSYS PRIVATE LIMITED",
                    Contact = new OpenApiContact() { Email = "info@finosys.com", Name = "Finosys" }
                });
                // Include 'SecurityScheme' to use JWT Authentication
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, new[] { "Bearer" } }
                });

            });
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
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IAuditorRepository, AuditorRepository>();
            services.AddScoped<IAuditTypeRepository, AuditTypeRepository>();
            services.AddScoped<ICheckpointsRepository, CheckpointsRepository>();
            services.AddScoped<ICPClassRepository, CPClassRepository>();
            services.AddScoped<ICPDeviationRepository, CPDeviationRepository>();
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IFaultGroupRepository, FaultGroupRepository>();
            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<IPlantRepository, PlantRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IShiftRepository, ShiftRepository>();
            services.AddScoped<IVariantRepository, VariantRepository>();
            services.AddScoped<IZoneRepository, ZoneRepository>();
            #endregion
            #region Services
            services.AddScoped<ResultModel>();
            services.AddScoped<TokenValidationParameters>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IAuditorService, AuditorService>();
            services.AddScoped<IAuditTypeService,AuditTypeService>();
            services.AddScoped<ICheckpointsService, CheckpointsService>();
            services.AddScoped<ICPClassService, CPClassService>();
            services.AddScoped<ICPDeviationService, CPDeviationService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IFaultGroupService, FaultGroupService>();
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IPlantService, PlantService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IShiftService, ShiftService>();
            services.AddScoped<IVariantService, VariantService>();
            services.AddScoped<IZoneService, ZoneService>();
            #endregion


        }
    }
}
