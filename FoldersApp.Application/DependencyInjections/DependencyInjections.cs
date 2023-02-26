using FoldersApp.Application.Services;
using FoldersApp.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FoldersApp.Application.DependencyInjections
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDigitalImgFolderService, DigitalImgFolderService>();
            services.AddScoped<IResourceFolderService, ResourceFolderService>();
            services.AddScoped<IEvidenceFolderService, EvidenceFolderService>();
            services.AddScoped<IGraphicProductFolderService, GraphicProductFolderService>();
            services.AddScoped<IPrimarySourceFolderService, PrimarySourceFolderService>();
            services.AddScoped<ISecondarySourceFolderService, SecondarySourceFolderService>();
            services.AddScoped<IProcessFolderService, ProcessFolderService>();
            services.AddScoped<IFinalProductFolderService, FinalProductFolderService>();

            return services;
        }
    }
}
