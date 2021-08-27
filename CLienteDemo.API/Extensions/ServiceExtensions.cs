using ClienteDemo.Infrastucture;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ClienteDemo.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
        }

        public static void ConfigureSwagger(this IServiceCollection services) =>
            services.AddSwaggerGen(s => s.SwaggerDoc("v0.15", new OpenApiInfo { Title = "ClienteDemo", Version = "v0.15" }));

        public static void ConfigureIISIntegration(this IServiceCollection services) 
        {
            services.Configure<IISOptions>(opt => { });
        }

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<DataContext>(opt => {
                opt.UseSqlServer(configuration.GetConnectionString("ConexaoBD"));
            });
        }
    }
}
