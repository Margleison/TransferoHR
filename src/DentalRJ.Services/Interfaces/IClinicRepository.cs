﻿using DentalRJ.Domain.Entities;
using DentalRJ.Services.Interfaces.Generic;
using DentalRJ.Services.Params;


namespace DentalRJ.Services.Interfaces
{
    public interface IClinicRepository : INamedEntityRepository<Clinic, ClinicParams>
    {
        Task<Clinic>? GetByTradeName(string tradeName, Guid? excId);
    }
}
