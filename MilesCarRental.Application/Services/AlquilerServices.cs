using MilesCarRental.Application.DTO.Request;
using MilesCarRental.Application.DTO.Response;
using MilesCarRental.Application.Mapper;
using MilesCarRental.Application.Services.Interfaces;
using MilesCarRental.Domain.IServices;
using MilesCarRental.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Services
{
    public class AlquilerServices : IAlquilerServices
    {
        private readonly IAlquilerServicesPort _alquilerServicesPort;

        public AlquilerServices(IAlquilerServicesPort alquilerServicesPort)
        {
            this._alquilerServicesPort = alquilerServicesPort;
        }

        public async Task CreateRental(AlquilerRequestDTO alquilerRequest)
        {
            var alquilerModel = alquilerRequest.MapToModel<AlquilerModel>();
            await _alquilerServicesPort.CreateRental(alquilerModel);
        }
    }
}
