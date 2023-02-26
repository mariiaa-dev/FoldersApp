using FoldersApp.Persistance.Context;
using FoldersApp.Persistance.Context.Interfaces;
using FoldersApp.Persistance.Repository;
using FoldersApp.Persistance.Repository.Interfaces;
using FoldersApp.Persistance.Seed.Initializer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoldersApp.Persistance.DependencyInjections
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string path)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile(path);

            var config = builder.Build();
            services.AddDbContext<IAppDbContext, AppDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")))
                .AddScoped<Initializer>();

            services.AddScoped<IDigitalImgFolderRepository, DigitalImgFolderRepository>();
            services.AddScoped<IResourceFolderRepository, ResourceFolderRepository>();
            services.AddScoped<IEvidenceFolderRepository, EvidenceFolderRepository>();
            services.AddScoped<IGraphicProductFolderRepository, GraphicProductFolderRepository>();
            services.AddScoped<IPrimarySourceFolderRepository, PrimarySourceFolderRepository>();
            services.AddScoped<ISecondarySourceFolderRepository, SecondarySourceFolderRepository>();
            services.AddScoped<IProcessFolderRepository, ProcessFolderRepository>();
            services.AddScoped<IFinalProductFolderRepository, FinalProductFolderRepository>();

            services.BuildServiceProvider()
            .GetService<Initializer>()
            ?.Initialize();

            return services;
        }
    }
}
