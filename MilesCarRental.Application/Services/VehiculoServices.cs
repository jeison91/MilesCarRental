using MilesCarRental.Application.DTO.Response;
using MilesCarRental.Application.Mapper;
using MilesCarRental.Application.Services.Interfaces;
using MilesCarRental.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Services
{
    public class VehiculoServices : IVehiculoServices
    {
        private readonly IVehiculoServicesPort _vehiculoServicesPort;

        public VehiculoServices(IVehiculoServicesPort vehiculoServicesPort)
        {
            this._vehiculoServicesPort = vehiculoServicesPort;
        }

        public async Task<List<VehiculoResponseDTO>> GetAvaliableCars(DateTime FechaRecoge, int LocalidadRecoge)
        {
            var vehiculoModel = await _vehiculoServicesPort.GetAvailable(FechaRecoge, LocalidadRecoge);
            var responseDTOs = VehiculoMapper.MapDTOList(vehiculoModel);
            return responseDTOs;
        }
    }
}
