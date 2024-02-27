using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.DTO.Request
{
    public class AlquilerRequestDTO
    {
        public int IdCliente { get; set; }
        public int IdVehiculo { get; set; }
        public int IdlocalidadRecoge { get; set; }
        public int IdLocalidadEntrega { get; set; }
        public DateTime FechaRecoge { get; set; }
        public int HoraRecoge { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int HoraEntrega { get; set; }
    }
}
