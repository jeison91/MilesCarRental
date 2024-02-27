using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MilesCarRental.Domain.Model
{
    public class VehiculoModel
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public int Modelo { get; set; }
        public int IdMarca { get; set; }
        public int IdLocalidadActual { get; set; }


        public MarcaModel Marca { get; set; }
        public LocalidadModel Localidad { get; set; }
        public virtual List<AlquilerModel> Alquileres { get; set; }
    }
}
