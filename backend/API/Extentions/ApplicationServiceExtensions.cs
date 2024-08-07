using System;
using API.Data;
using API.Models;
using MongoDB.Driver;

namespace API.Extentions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            var mongoDBSettings = config.GetSection("MongoDB").Get<MongoDBSettings>();

            services.AddSingleton<IMongoClient>(new MongoClient(mongoDBSettings.ConnectionString));
            services.AddScoped<IMongoDatabase>(provider =>
            {
                var client = provider.GetRequiredService<IMongoClient>();
                return client.GetDatabase(mongoDBSettings.DatabaseName);
            });

            services.AddScoped<IRepository<Country>, CountryRepository>();
            services.AddScoped<IRepository<Specialite>, SpecialiteRepository>();
            return services;
        }
    }
}

