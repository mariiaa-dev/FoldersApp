using FoldersApp.Application.DTOs;
using FoldersApp.Persistance.Domains.Models;

namespace FoldersApp.Application.Services.Interfaces
{
    public interface IEvidenceFolderService
    {
        EvidenceFolderDTO GetEvidenceFolder();
    }
}
