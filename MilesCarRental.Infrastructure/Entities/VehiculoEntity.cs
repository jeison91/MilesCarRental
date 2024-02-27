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
    public class VehiculoEntity
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Placa")]
        [Column(Order = 2)]
        public string Placa { get; set; }

        [Required]
        [Display(Name = "Modelo")]
        [Column(Order = 3)]
        public int Modelo { get; set; }

        [Required]
        [MaxLength(13)]
        [Display(Name = "IdMarca")]
        [Column(Order = 4)]
        public int IdMarca { get; set; }
        [ForeignKey("IdMarca")]
        public MarcaEntity Marca { get; set; }

        [Required]
        [Column(Order = 5)]
        public int? IdLocalidadActual { get; set; }
        [ForeignKey("IdLocalidadActual")]
        public LocalidadEntity Localidad { get; set; }

        public virtual List<AlquilerEntity> Alquileres { get; set; }
    }
}
