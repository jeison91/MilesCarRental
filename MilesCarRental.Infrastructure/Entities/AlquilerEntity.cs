using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MilesCarRental.Infrastructure.Entities
{
    public class AlquilerEntity
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(Order = 2)]
        public int IdCliente{ get; set; }
        [ForeignKey("IdCliente")]
        public ClienteEntity Cliente { get; set; }

        [Required]
        [Column(Order = 3)]
        public int IdVehiculo { get; set; }
        [ForeignKey("IdVehiculo")]
        public VehiculoEntity Vehiculo { get; set; }

        [Required]
        [Column(Order = 4)]
        public int IdlocalidadRecoge { get; set; }
        [ForeignKey("IdlocalidadRecoge")]
        public LocalidadEntity localidadRecoge { get; set; }

        [Required]
        [Column(Order = 5)]
        public int IdLocalidadEntrega { get; set; }
        [ForeignKey("IdLocalidadEntrega")]
        public LocalidadEntity LocalidadEntrega { get; set; }

        [Required]
        [Column(Order = 6)]
        public DateTime FechaRecoge { get; set; }

        [Required]
        [Column(Order = 7)]
        public int HoraRecoge { get; set; }

        [Required]
        [Column(Order = 8)]
        public DateTime FechaEntrega { get; set; }

        [Required]
        [Column(Order = 9)]
        public int HoraEntrega { get; set; }
    }
}
