using MilesCarRental.Application.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Services.Interfaces
{
    public interface IVehiculoServices
    {
        Task<List<VehiculoResponseDTO>> GetAvaliableCars(DateTime FechaRecoge, int LocalidadRecoge);
    }
}
