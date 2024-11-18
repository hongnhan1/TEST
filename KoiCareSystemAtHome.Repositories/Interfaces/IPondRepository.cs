﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiCareSystemAtHome.Repositories.Entities;

namespace KoiCareSystemAtHome.Repositories.Interfaces
{
    public interface IPondRepository
    {
        Task<List<Pond>> GetAllPond();
        Boolean AddPond(Pond pond);
        Boolean DeletePond(Guid Id);
        Boolean DeletePond(Pond pond);
        Task<Pond> GetPonById(Guid Id);
        Boolean UpdatePond(Pond pond);
        Task<Pond> GetPondById(Guid id);
        Task<List<Pond>> SearchPondAsync(string searchTerm);
    }
}
