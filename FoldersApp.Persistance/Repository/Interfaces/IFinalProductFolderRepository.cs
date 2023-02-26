﻿using FoldersApp.Persistance.Domains.Models;
using Microsoft.EntityFrameworkCore;

namespace FoldersApp.Persistance.Repository.Interfaces
{
    public interface IFinalProductFolderRepository
    {
        DbSet<FinalProductFolder>? GetFinalProductFolder();
    }
}
