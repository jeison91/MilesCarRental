using MilesCarRental.Domain.Exceptions;
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
    public class AlquilerUseCase : IAlquilerServicesPort
    {
        private readonly IAlquilerRepository _alquilerRepository;
        private readonly IVehiculoRepository _vehiculoRepository;

        public AlquilerUseCase(IAlquilerRepository alquilerRepository, IVehiculoRepository vehiculoRepository)
        {
            this._alquilerRepository = alquilerRepository;
            this._vehiculoRepository = vehiculoRepository;
        }

        public async Task<AlquilerModel> CreateRental(AlquilerModel alquilerModel)
        {
            //Validar si se puede rentar
            var vehiculoModels = await _vehiculoRepository.AvailableCarsAsync(alquilerModel.FechaRecoge, alquilerModel.IdlocalidadRecoge);

            if (vehiculoModels.Where(x => x.Id == alquilerModel.IdVehiculo) == null)
                throw new DomainValidateException("El Vehículo ya no está disponible.");
            if (vehiculoModels.Count <= 0)
                throw new DomainValidateException("No hay vehiculos disponibles.");

            var responseAlquilerModel = await _alquilerRepository.CreateRentalAsync(alquilerModel);

            //Actualizar futura ubicación
            var vehiculoModel = await _vehiculoRepository.GetById(alquilerModel.IdVehiculo);
            vehiculoModel.IdLocalidadActual = alquilerModel.IdLocalidadEntrega;
            await _vehiculoRepository.Update(vehiculoModel);

            return responseAlquilerModel;
        }
    }
}
