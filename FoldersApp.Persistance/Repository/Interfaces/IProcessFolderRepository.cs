using FoldersApp.Persistance.Domains.Models;
using Microsoft.EntityFrameworkCore;

namespace FoldersApp.Persistance.Repository.Interfaces
{
    public interface IProcessFolderRepository
    {
        DbSet<ProcessFolder>? GetProcessFolder();
    }
}
