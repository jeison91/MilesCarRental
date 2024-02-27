using Microsoft.EntityFrameworkCore;
using MilesCarRental.Domain.IRepository;
using MilesCarRental.Domain.Model;
using MilesCarRental.Infrastructure.Entities;
using MilesCarRental.Infrastructure.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Infrastructure.Repository
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly CarRentalDbContext _dBContext;
        public VehiculoRepository(CarRentalDbContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<VehiculoModel> GetById(int idVehiculo)
        {
            var vehiculoEntity = await _dBContext.Vehiculos
                .Include(m => m.Marca)
                .Include(l => l.Localidad)
                .Where(x => x.Id == idVehiculo).FirstOrDefaultAsync();

            var vehiculoModel = vehiculoEntity.MapToEntity<VehiculoModel>();
            return vehiculoModel;
        }

        public async Task<List<VehiculoModel>> AvailableCarsAsync(DateTime FechaRecoge, int LocalidadRecoge)
        {
            var vehiculosDisponibles = await _dBContext.Vehiculos
                .Include(m => m.Marca)
                .Include(l => l.Localidad)
                .Where(v => !_dBContext.Alquileres
                .Any(alquiler => alquiler.IdVehiculo == v.Id &&
                        alquiler.IdLocalidadEntrega == LocalidadRecoge &&
                        FechaRecoge >= alquiler.FechaRecoge &&
                        FechaRecoge <= alquiler.FechaEntrega) &&
                        v.IdLocalidadActual == LocalidadRecoge).ToListAsync();

            var model = vehiculosDisponibles.MapToEntity<List<VehiculoModel>>();
            return model;
        }

        public async Task<VehiculoModel> Update(VehiculoModel vehiculoModel)
        {
            var vehiculoEntity = vehiculoModel.MapToEntity<VehiculoEntity>();
            _dBContext.Entry(vehiculoEntity).State = EntityState.Modified;
            await _dBContext.SaveChangesAsync();
            return vehiculoModel;
        }
    }
}
