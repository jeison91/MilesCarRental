using MilesCarRental.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Domain.IRepository
{
    public interface IVehiculoRepository
    {
        Task<VehiculoModel> GetById(int idVehiculo);
        Task<List<VehiculoModel>> AvailableCarsAsync(DateTime FechaRecoge, int LocalidadRecoge);

        Task<VehiculoModel> Update(VehiculoModel order);
    }
}
