using Application.Addresses;
using Application.Businesses;
using Application.Core;
using Application.Phones;
using Application.Photos;
using Application.Repositories;
using Infrastructure.Photos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Persistence;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "API", Version = "v1"}); });
            
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IBusinessesRepository, EfCoreBusinessesRepository>();
            
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy",
                builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            
            //Need to register, and tell where the handlers are, we are on API assembly, need to tell it to go to Application assembly 
            services.AddMediatR(typeof(List.Handler).Assembly);
            services.AddAutoMapper(typeof(List.Handler).Assembly);
            services.AddScoped<IPhotoAccessor, PhotoAccessor>();
            services.AddScoped<IPhonesRepository, EfCorePhonesRepository>();
            services.AddScoped<IAddressesRepository, EfCoreAddressesRepository>();
            services.Configure<CloudinarySettings>(config.GetSection("Cloudinary"));

            return services;
            
        }
    }
}