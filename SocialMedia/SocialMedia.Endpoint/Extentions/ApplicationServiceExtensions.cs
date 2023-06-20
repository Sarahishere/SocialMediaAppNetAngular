
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Persistence;
using SocialMedia.Persistence.Data;
using SocialMedia.Persistence.Interfaces;
using SocialMedia.Persistence.Services;

namespace SocialMedia.Endpoint.Extentions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, 
        IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt => 
              {
               opt.UseSqlServer(config.GetConnectionString("DefaultConnectionString"));
              });

            services.AddApiVersioning(opt =>
            {
                opt.ReportApiVersions = true;
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = ApiVersion.Default;
            });
            services.AddCors();
            services.AddScoped<ITokenService,TokenService>();
            services.AddScoped<IUnitOfWork , UnitOfWork>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            return services;
            
        }
    }
}