using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaApi.DTO
{
    public class TiphabidtoTipoHabitacionDto
    {
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        [Required]
        [StringLength(20)]
        public string codigo { get; set; }

        [StringLength(255)]
        public string descripcion { get; set; }

        [Required]
        public bool es_activo { get; set; }

        public ICollection<HabidtoHabitacionDto>? HabitacionesDtos { get; set; }
    }
}

