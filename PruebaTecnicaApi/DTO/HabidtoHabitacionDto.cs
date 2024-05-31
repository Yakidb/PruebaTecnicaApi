using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnicaApi.DTO
{
    public class HabidtoHabitacionDto
    {
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        [StringLength(255)]
        public string descripcion { get; set; }

        [Required]
        public int cantidad { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal precio { get; set; }

        [Required]
        [StringLength(20)]
        public string codigo { get; set; }

        [Required]
        public bool es_activo { get; set; }

        [Required]
        public int host_id { get; set; }

        [Required]
        public int tipo_habitacion_id { get; set; }
    }
}
