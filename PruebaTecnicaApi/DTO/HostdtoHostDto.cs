using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaApi.DTO
{
    public class HostdtoHostDto
    {
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string email { get; set; }

        [Phone]
        [StringLength(20)]
        public string telefono { get; set; }

        [StringLength(13)]
        public string RFC { get; set; }

        [StringLength(100)]
        public string razon_social { get; set; }

        [Required]
        public bool es_activo { get; set; }

        public ICollection<HabidtoHabitacionDto>? HabitacionesDtos { get; set; }
    }
}
