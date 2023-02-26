using Microsoft.Extensions.DependencyInjection;
using FoldersApp.Dberializator.DbSerializator;
using FoldersApp.DbSerializator.DbSerializator.Interfaces;

namespace FoldersApp.DbSerializator.DependencyInjections
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddDbSerialization(this IServiceCollection services)
        {
            services.AddScoped<ISerializator, Serializator>();

            return services;
        }
    }
}
