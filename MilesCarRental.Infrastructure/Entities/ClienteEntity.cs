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
    public class ClienteEntity
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Documento")]
        [Column(Order = 2)]
        public string Documento { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Nombre")]
        [Column(Order = 3)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(13)]
        [Display(Name = "Telefono")]
        [Column(Order = 4)]
        public string Telefono { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Direccion")]
        [Column(Order = 5)]
        public string Direccion { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Email")]
        [Column(Order = 6)]
        public string Email { get; set; }
    }
}
