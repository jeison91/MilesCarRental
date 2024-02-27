using MilesCarRental.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.DTO.Response
{
    public class VehiculoResponseDTO
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public int Modelo { get; set; }
        public string Marca { get; set; }
        public string UbicacionActual { get; set; }
    }
}
