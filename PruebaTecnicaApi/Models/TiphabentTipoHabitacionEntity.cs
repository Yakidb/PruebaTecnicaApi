using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnicaApi.Models
{
    [Table("tipo_habitacion")]
    public class TiphabentTipoHabitacionEntity
    {
        //--------------------------------------------------------------------------------------------------------------
        /*PRIMARY KEY*/
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        //--------------------------------------------------------------------------------------------------------------
        /*COLUMNS*/
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

        //--------------------------------------------------------------------------------------------------------------
        /*NAVEGATION*/
        public ICollection<HabentHabitacionEntity> HabitacionesEntity { get; set; }
    }
}
