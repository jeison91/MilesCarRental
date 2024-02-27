using MilesCarRental.Domain.IRepository;
using MilesCarRental.Domain.IServices;
using MilesCarRental.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Domain.UseCase
{
    public class VehiculoUseCase : IVehiculoServicesPort
    {
        private readonly IVehiculoRepository _vehiculoRepository;

        public VehiculoUseCase(IVehiculoRepository vehiculoRepository)
        {
            this._vehiculoRepository = vehiculoRepository;
        }

        public async Task<List<VehiculoModel>> GetAvailable(DateTime FechaRecoge, int LocalidadRecoge)
        {
            var vehiculoModel = await _vehiculoRepository.AvailableCarsAsync(FechaRecoge, LocalidadRecoge);
            return vehiculoModel;
        }
    }
}
