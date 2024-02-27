using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Domain.Model
{
    public class AlquilerModel
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdVehiculo { get; set; } 
        public int IdlocalidadRecoge { get; set; }
        public int IdLocalidadEntrega { get; set; }    
        public DateTime FechaRecoge { get; set; }
        public int HoraRecoge { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int HoraEntrega { get; set; }

        //public ClienteEntity Cliente { get; set; }
        //public VehiculoEntity Vehiculo { get; set; }
        //public LocalidadEntity localidadRecoge { get; set; }
        //public LocalidadEntity LocalidadEntrega { get; set; }
    }
}
