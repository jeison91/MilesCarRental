﻿using MilesCarRental.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Domain.IRepository
{
    public interface IAlquilerRepository
    {
        Task<AlquilerModel> CreateRentalAsync(AlquilerModel alquilerModel);
    }
}
