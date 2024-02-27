using MilesCarRental.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Domain.IServices
{
    public interface IVehiculoServicesPort
    {
        Task<List<VehiculoModel>> GetAvailable(DateTime FechaRecoge, int LocalidadRecoge);
    }
}
