using MilesCarRental.Application.DTO.Request;
using MilesCarRental.Application.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Services.Interfaces
{
    public interface IAlquilerServices
    {
        Task CreateRental(AlquilerRequestDTO alquilerRequest);
    }
}
